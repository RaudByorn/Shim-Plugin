using System;

namespace ShimPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "радиус внешнего обода" задан неправильно.
    /// </summary>
    public class OuterRadiusException:ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public OuterRadiusException(string message) : base(message)
        {

        }
    }
}
