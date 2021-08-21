using System.Collections.Generic;

namespace WebApiPsychic
{
    public class PsychicMan
    {
        /// <summary>
        /// Имя экстрасенса
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Значение достоверности
        /// </summary>
        public int Authenticity { get; set; }
        /// <summary>
        /// Список догадок (предположений)
        /// </summary>
        public List<int> Guesses { get; set; }
        /// <summary>
        /// Текущая догадка
        /// </summary>
        public int Сurrent_guess { get; set; }
    }
}
