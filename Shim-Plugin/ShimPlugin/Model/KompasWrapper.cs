using System;

using Kompas6API5;
using Kompas6Constants3D;

namespace ShimPlugin.Model
{
    /// <summary>
    /// Класс для взаимодействия с KOMPAS
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// Объект KOMPAS API
        /// </summary>
        private KompasObject _kompas = null;

        /// <summary>
        /// Запуск KOMPAS если он не запущен.
        /// </summary>
        public void StartKompas()
        {
            if (_kompas == null)
            {
                Type kompasType = 
                    Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = 
                    (KompasObject)Activator.CreateInstance(kompasType);
            }

            if (_kompas != null)
            {
                try
                {
                    _kompas.Visible = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    Type kompasType = 
                        Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = 
                        (KompasObject)Activator.CreateInstance(kompasType);
                    _kompas.Visible = true;
                }
                _kompas.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Построить шайбу по параметрам
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        public void BuildShim(ShimSettings shimSettings)
        {
            if (_kompas == null)
            {
                throw new ApplicationException(
                    "Не возможно построить деталь. Нет связи с Kompas3D.");
            }

            if (shimSettings == null)
            {
                throw new ApplicationException(
                    "Не возможно построить деталь. Ссылка на деталь пуста.");
            }

            ksPart shim = CreateShim(shimSettings);

            bool needGroove = shimSettings.GrooveRadius > 0;
            if (needGroove)
            {
                CreateGroove(shimSettings, shim);
            }
        }

        /// <summary>
        /// Построение детали "шайба с пазом"
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        /// <returns>Возвращает компонент сборки</returns>
        private ksPart CreateShim(ShimSettings shimSettings)
        {
            // Создание документа детели

            ksDocument3D document3D = _kompas.Document3D();
            document3D.Create();

            // Получим верхнюю часть сборки
            ksPart part = document3D.GetPart((short)Part_Type.pTop_Part);

            // Создание эскиза для шайбы

            ksEntity sketchShim;
            ksSketchDefinition sketchShimDefinition;
            CreateSketch(part, out sketchShim, out sketchShimDefinition,
                (short)Obj3dType.o3d_planeXOY);

            // Рисуем на эскизе шайбу

            ksDocument2D shimEdit = sketchShimDefinition.BeginEdit();
            DrawShim(shimSettings, shimEdit);
            sketchShimDefinition.EndEdit();

            // Вращением выдавливаем шайду

            ksEntity rotate = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition rotateDefinition = 
                (ksBossRotatedDefinition)rotate.GetDefinition();
            rotateDefinition.directionType = (short)Direction_Type.dtNormal;
            rotateDefinition.SetSideParam(true, 360);
            rotateDefinition.toroidShapeType = false;
            rotateDefinition.SetSketch(sketchShim);
            rotate.Create();

            return part;
        }

        /// <summary>
        /// Нарисовать шайбу на эскизе
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        /// <param name="shimEdit">Чертеж</param>
        private static void DrawShim(ShimSettings shimSettings, 
            ksDocument2D shimEdit)
        {
            DrawShimLines(shimSettings, shimEdit);
            DrawShimInnerFillet(shimSettings, shimEdit);
            DrawShimOuterFillet(shimSettings, shimEdit);

            // Рисуем осевую линию
            shimEdit.ksLineSeg(0, -5, 0, 5, 3);
        }

        /// <summary>
        /// Нарисовать внешненее скругление шайбы
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        /// <param name="shimEdit">Чертеж</param>
        private static void DrawShimOuterFillet(ShimSettings shimSettings, 
            ksDocument2D shimEdit)
        {
            if (shimSettings.OuterFillet > 0)
            {
                shimEdit.ksArcByPoint(
                    shimSettings.OuterRadius - shimSettings.OuterFillet,
                    shimSettings.Height / 2 - shimSettings.OuterFillet,
                    shimSettings.OuterFillet,
                    shimSettings.OuterRadius - shimSettings.OuterFillet,
                    shimSettings.Height / 2,
                    shimSettings.OuterRadius,
                    shimSettings.Height / 2 - shimSettings.OuterFillet,
                    -1, 1);
            }
            if (shimSettings.OuterFillet != shimSettings.Height)
            {
                shimEdit.ksLineSeg(shimSettings.OuterRadius,
                    shimSettings.Height / 2 - shimSettings.OuterFillet,
                    shimSettings.OuterRadius,
                    -shimSettings.Height / 2 + shimSettings.OuterFillet, 1);
            }
            if (shimSettings.OuterFillet > 0)
            {
                shimEdit.ksArcByPoint(
                    shimSettings.OuterRadius - shimSettings.OuterFillet,
                    -shimSettings.Height / 2 + shimSettings.OuterFillet,
                    shimSettings.OuterFillet,
                    shimSettings.OuterRadius - shimSettings.OuterFillet,
                    -shimSettings.Height / 2, shimSettings.OuterRadius,
                    -shimSettings.Height / 2 + shimSettings.OuterFillet, 
                    1, 1);
            }
        }

        /// <summary>
        /// Нарисовать внутреннее скругление шайбы
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        /// <param name="shimEdit">Чертеж</param>
        private static void DrawShimInnerFillet(ShimSettings shimSettings, 
            ksDocument2D shimEdit)
        {
            if (shimSettings.InnerFillet > 0)
            {
                shimEdit.ksArcByPoint(
                    shimSettings.InnerRadius + shimSettings.InnerFillet,
                    shimSettings.Height / 2 - shimSettings.InnerFillet,
                    shimSettings.InnerFillet,
                    shimSettings.InnerRadius + shimSettings.InnerFillet,
                    shimSettings.Height / 2, shimSettings.InnerRadius,
                    shimSettings.Height / 2 - shimSettings.InnerFillet, 
                    1, 1);
            }
            if (shimSettings.InnerFillet != shimSettings.Height / 2)
            {
                shimEdit.ksLineSeg(shimSettings.InnerRadius,
                    shimSettings.Height / 2 - shimSettings.InnerFillet,
                    shimSettings.InnerRadius,
                    -shimSettings.Height / 2 + shimSettings.InnerFillet, 1);
            }
            if (shimSettings.InnerFillet > 0)
            {
                shimEdit.ksArcByPoint(
                    shimSettings.InnerRadius + shimSettings.InnerFillet,
                    -shimSettings.Height / 2 + shimSettings.InnerFillet,
                    shimSettings.InnerFillet,
                    shimSettings.InnerRadius + shimSettings.InnerFillet,
                    -shimSettings.Height / 2, shimSettings.InnerRadius,
                    -shimSettings.Height / 2 + shimSettings.InnerFillet, 
                    -1, 1);
            }
        }

        /// <summary>
        /// Нарисовать линии на чертеже шайбы
        /// </summary>
        /// <param name="shimSettings">Параметры шайбы</param>
        /// <param name="shimEdit">Чертеж</param>
        private static void DrawShimLines(ShimSettings shimSettings,
            ksDocument2D shimEdit)
        {
            shimEdit.ksLineSeg(
                shimSettings.InnerRadius + shimSettings.InnerFillet,
                shimSettings.Height / 2,
                shimSettings.OuterRadius - shimSettings.OuterFillet,
                shimSettings.Height / 2, 1);
            shimEdit.ksLineSeg(
                shimSettings.InnerRadius + shimSettings.InnerFillet,
                -shimSettings.Height / 2,
                shimSettings.OuterRadius - shimSettings.OuterFillet,
                -shimSettings.Height / 2, 1);
        }

        /// <summary>
        /// Создать эскиз
        /// </summary>
        /// <param name="part">Компонент сборки</param>
        /// <param name="sketch">Эскиз</param>
        /// <param name="sketchDefinition">Параметры эскиза</param>
        /// <param name="planeid">Плоскость</param>
        private static void CreateSketch(ksPart part, out ksEntity sketch, 
            out ksSketchDefinition sketchDefinition, short planeid)
        {
            ksEntity plane = part.GetDefaultEntity(planeid);
            sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();
        }

        /// <summary>
        /// Создать паз
        /// </summary>
        /// <param name="shim">Параметры шайбы</param>
        /// <param name="part">Компонент сборки</param>
        private void CreateGroove(ShimSettings shim, ksPart part)
        {
            // Создаем эскиз для паза

            ksEntity sketchGroove;
            ksSketchDefinition sketchGrooveDefinition;
            CreateSketch(part, out sketchGroove, out sketchGrooveDefinition, 
                (short)Obj3dType.o3d_planeXOZ);


            // Рисуем паз на эскизе
            
            ksDocument2D GrooveEdit = sketchGrooveDefinition.BeginEdit();
            GrooveEdit.ksCircle(shim.InnerRadius, 0, shim.GrooveRadius, 1);
            sketchGrooveDefinition.EndEdit();

            // Вырезаем паз

            ksEntity cutGrooveExtrude = 
                part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutGrooveExtrudeDefinition = 
                cutGrooveExtrude.GetDefinition();
            cutGrooveExtrudeDefinition.directionType = 
                (short)Direction_Type.dtBoth;
            cutGrooveExtrudeDefinition.SetSketch(sketchGroove);
            ksExtrusionParam cutGrooveExtrudeParam = 
                cutGrooveExtrudeDefinition.ExtrusionParam();
            cutGrooveExtrudeParam.depthNormal = shim.Height;
            cutGrooveExtrudeParam.depthReverse = shim.Height;
            cutGrooveExtrude.Create();
        }
    }
}