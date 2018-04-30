using System;

namespace ShimPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "радиус паза" задан неправильно.
    /// </summary>
    public class GrooveRadiusException:ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public GrooveRadiusException(string message) : base(message)
        {

        }
    }
}
