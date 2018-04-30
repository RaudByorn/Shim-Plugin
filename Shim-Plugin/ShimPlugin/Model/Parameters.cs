using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShimPlugin.Model;
using System.Windows.Forms;
using ShimPlugin.Model.Exceptions;


namespace ShimPlugin.Model
{
    class Parameters
    {
        /// <summary>
        /// Метод для проверки внутреннего радиуса шайбы
        /// </summary>
        /// <param name="radiusValue"></param>
        /// <returns></returns>
        public double InnerRaduisValidator(double radiusValue)
        {
            if (!IsValidDouble(radiusValue))
            {
                throw new InnerRadiusException(
                    "Заданный внутренний радиус - "
                    + "не вещественное число.");
            }
            else if(!(radiusValue >= 10))
            {
                throw new InnerRadiusException(
                    "Внутренний радиус не может быть меньше 10 мм.");
            }
            else if (!(radiusValue <= 500))
            {
                throw new InnerRadiusException(
                    "Внутренний радиус не может быть больше 500 мм.");
            }
            else
            {
                return radiusValue;
            }
        }

        /// <summary>
        /// Метод для проверки внешнего радиуса шайбы
        /// </summary>
        /// <param name="radiusValue"></param>
        /// <param name="InnerRadius"></param>
        /// <returns></returns>
        public double OuterRadiusValidator(double radiusValue,double innerRadius)
        {
            if (!IsValidDouble(radiusValue))
            {
                throw new OuterRadiusException(
                    "Заданный внешний радиус - не вещественное число.");
            }
            else if (!(radiusValue >= 10))
            {
                throw new OuterRadiusException(
                    "Внешний радиус не может быть меньше 10 мм.");
            }
            else if (!(radiusValue <= 1000))
            {
                throw new OuterRadiusException(
                    "Внешний радиус не может быть больше 1000 мм.");
            }
            else if (!(radiusValue >= innerRadius))
            {
                throw new OuterRadiusException(
                    "Внешний радиус "
                    + "должен быть больше " + innerRadius.ToString());
            }
            else
            {
                return radiusValue;
            }
        }

        /// <summary>
        /// Метод для проверки скругления
        /// </summary>
        /// <param name="filletValue"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public double FilletValidator (double filletValue, double height)
        {
            if (!IsValidDouble(filletValue))
            {
                throw new FilletException(
                    "Заданное cкругление - "
                    + "не вещественное число.");
            }
            else if (!(filletValue >= 0))
            {
                throw new FilletException(
                    "Cкругление не может быть меньше 0 мм.");
            }
            else if(!(filletValue <= 250))
            {
                throw new FilletException(
                    "Cкругление не может быть больше 250 мм.");
            }
            else if (!(filletValue <= height / 2))
            {
                throw new FilletException(
                    "Cкругление должно быть меньше или равно " + (height / 2).ToString());
            }
            else
            {
                return filletValue;
            }
        }

        /// <summary>
        /// Метод для проверки высоты шайбы
        /// </summary>
        /// <param name="heightValue"></param>
        /// <returns></returns>
        public double HeightValidator(double heightValue)
        {
            if (!IsValidDouble(heightValue))
            {
                throw new HeightException(
                    "Заданная высота - не вещественное число.");
            }
            else if (!(heightValue >= 10))
            {
                throw new HeightException(
                    "Высота не может быть меньше 10 мм.");
            }
            else if (!(heightValue <= 500))
            {
                throw new HeightException(
                    "Высота не может быть больше 500 мм.");
            }
            else
            {
                return heightValue;
            }
        }

        /// <summary>
        /// Метод для проверки радиуса пазы
        /// </summary>
        /// <param name="grooveRadiusValue"></param>
        /// <param name="OuterRadius"></param>
        /// <param name="InnerRadius"></param>
        /// <returns></returns>
        public double GrooveRadiusValidator(double grooveRadiusValue, double outerRadius, double innerRadius)
        {
            if (!IsValidDouble(grooveRadiusValue))
            {
                throw new GrooveRadiusException(
                    "Заданный радиус паза - не вещественное число.");
            }
            else if (!(grooveRadiusValue >= 0))
            {
                throw new GrooveRadiusException(
                    "Радиус паза не может быть меньше 0 мм.");
            }
            else if (!(grooveRadiusValue <= 250))
            {
                throw new GrooveRadiusException(
                    "Радиус паза не может быть больше 250 мм.");
            }
            else if (!(grooveRadiusValue <= (outerRadius - innerRadius) / 2))
            {
                throw new GrooveRadiusException(
                    "Радиус паза "
                    + "должен быть меньше или равен " + ((outerRadius - innerRadius) / 2).ToString()
                    + "между внешним и внутренним радиусами, "
                    + "поскольку это нарушает целостность шайбы.");
            }
            else
            {
                return grooveRadiusValue;
            }
        }

        /// <summary>
        /// Проверка валидности дабла на константы 
        /// (минимальная и максимальная граница числа,
        /// бесконченость, не число)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Возвращает true если проверка пройдена успешно</returns>
        private bool IsValidDouble(double value)
        {
            if (value < Double.MinValue
                || value > Double.MaxValue
                || Double.IsInfinity(value)
                || Double.IsNaN(value)
            )
            {
                return false;
            }

            return true;
        }

    }
}
