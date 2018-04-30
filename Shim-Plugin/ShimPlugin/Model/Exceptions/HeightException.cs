using System;

namespace ShimPlugin.Model.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает в случае, если параметр 
    /// "высота шайбы" задан неправильно.
    /// </summary>
    public class HeightException :ApplicationException
    {
        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Подробный текст исключения</param>
        public HeightException(string message) : base(message)
        {

        }
    }
}
