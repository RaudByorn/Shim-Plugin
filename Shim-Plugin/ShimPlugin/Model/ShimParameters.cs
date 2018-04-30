using System;

using ShimPlugin.Model.Exceptions;

namespace ShimPlugin.Model
{
    /// <summary>
    /// Параметры шайбы
    /// </summary>
    public class ShimSettings
    {
        /// <summary>
        /// Объект класса Parameters для валидации значений шайбы
        /// </summary>
        Parameters valueValidator = new Parameters();

        /// <summary>
        /// Переменная внутреннего радиуса
        /// </summary>
        private double _innerRadius;

        /// <summary>
        /// Переменная внешнего радиуса
        /// </summary>
        private double _outerRadius;

        /// <summary>
        /// Переменная высоты
        /// </summary>
        private double _height;

        /// <summary>
        /// Переменная внутреннего скругления
        /// </summary>
        private double _innerFillet;

        /// <summary>
        /// Переменная внешнего скругления
        /// </summary>
        private double _outerFillet;

        /// <summary>
        /// Переменная паза шайбы
        /// </summary>
        private double _grooveRadius;

        /// <summary>
        /// Конструктор шайбы с 6 параметрами
        /// </summary>
        /// <param name="innerRadius">Радиус внутреннего обода</param>
        /// <param name="outerRadius">Радиус внешнего обода</param>
        /// <param name="height">Высота шайбы</param>
        /// <param name="innerFillet">Радиус внутреннего скругления</param>
        /// <param name="outerFillet">Радиус внешнего обода</param>
        /// <param name="grooveRadius">Радиус паза</param>
        public ShimSettings(double innerRadius, double outerRadius, 
            double height, double innerFillet, double outerFillet, 
            double grooveRadius)
        {
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
            Height = height;
            InnerFillet = innerFillet;
            OuterFillet = outerFillet;
            GrooveRadius = grooveRadius;
        }

        /// <summary>
        /// Внутренний радиус
        /// </summary>
        public double InnerRadius
        {
            get
            {
                return _innerRadius;
            }
            private set
            {   
                _innerRadius = valueValidator.InnerRaduisValidator(value);
            }
        }

        /// <summary>
        /// Внешний радиус
        /// </summary>
        public double OuterRadius
        {
            get
            {
                return _outerRadius;
            }
            private set
            {
                _outerRadius = valueValidator.OuterRadiusValidator(value, InnerRadius);
            }
        }

        /// <summary>
        /// Высота
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            private set
            {
                
                _height = valueValidator.HeightValidator(value);
            }
        }

        /// <summary>
        /// Внутреннее скругление
        /// </summary>
        public double InnerFillet
        {
            get
            {
                return _innerFillet;
            }
            private set
            {
                _innerFillet = valueValidator.FilletValidator(value, Height);
            }
        }

        /// <summary>
        /// Внешнее скругление
        /// </summary>
        public double OuterFillet
        {
            get
            {
                return _outerFillet;
            }
            private set
            {
                _outerFillet = valueValidator.FilletValidator(value, Height);
            }
        }

        /// <summary>
        /// Радиус паза
        /// </summary>
        public double GrooveRadius
        {
            get
            {
                return _grooveRadius;
            }
            private set
            {
                _grooveRadius = valueValidator.GrooveRadiusValidator(value, OuterRadius, InnerRadius);
            }
        }
    }
}
