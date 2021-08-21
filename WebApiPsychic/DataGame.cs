using System.Collections.Generic;

namespace WebApiPsychic
{
    public class DataGame
    {
        /// <summary>
        /// Список экстрасенсов
        /// </summary>
        public List<PsychicMan> Psychics { get; set; }
        /// <summary>
        /// Список загаданных игроком чисел
        /// </summary>
        public List<int>  Player_Numbers { get; set; }
    }
}
