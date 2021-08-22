using System;

namespace WebApiPsychic.Common.Exception
{
    public class BadRequestException : SystemException
    {
        public BadRequestException(int i)
           : base($"Число {i} не допустимо. Загаданное число должно быть от 1 до 4") { }
    }
}
