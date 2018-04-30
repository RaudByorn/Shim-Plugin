using System;

namespace ShimPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "радиус внешнего скругления" задан неправильно.
    /// </summary>
    public class FilletException : ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public FilletException(string message) : base(message)
        {

        }
    }
}
