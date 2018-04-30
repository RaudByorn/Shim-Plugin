using System;

namespace ShimPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "радиус внешнего обода" задан неправильно.
    /// </summary>
    public class InnerRadiusException:ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public InnerRadiusException(string message) : base(message)
        {
        }
    }
}
