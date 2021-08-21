using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiPsychic.Controllers
{
    [ApiController]
    [Route("api/datagame")]
    public class DataGameController : ControllerBase
    {
        private readonly ILogger<DataGameController> _logger;
        public DataGameController(ILogger<DataGameController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Получение предполагаемых чисел в начале раунда от экстрасенсов
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / StartGame
        /// </remarks>
        /// <returns>Returns DataGame</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("startgame")]
        public IActionResult StartGame()
        {
            if (HttpContext.Session.Keys.Contains("dataGame"))
            {
                DataGame dataGame = HttpContext.Session.Get<DataGame>("dataGame");

                foreach (PsychicMan man in dataGame.Psychics)
                {
                    man.Сurrent_guess = new Random().Next(1, 4);
                    man.Guesses.Add(man.Сurrent_guess);
                }
                HttpContext.Session.Set("dataGame", dataGame);
                return Ok(dataGame);
            }
            else
            {
                DataGame dataGame = new DataGame
                {
                    Psychics = new List<PsychicMan>
                    {
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Сurrent_guess = new Random().Next(1, 4),
                            Guesses = new List<int>(),
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        }
                    },
                    Player_Numbers = new List<int>()
                };
                foreach (PsychicMan man in dataGame.Psychics)
                {
                    //var current = man.Сurrent_guess;
                    man.Guesses.Add(man.Сurrent_guess);
                }
                HttpContext.Session.Set("dataGame", dataGame);
                return Ok(dataGame);
            }
        }

        /// <summary>
        /// Получение уровня достоверности экстрасенсов 
        /// в конце раунда 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / EndRound
        /// </remarks>
        /// <returns>Returns DataGame</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("endround")]
        public IActionResult EndRound(int secretNumber)
        {
            if (HttpContext.Session.Keys.Contains("dataGame"))
            {
                DataGame dataGame = HttpContext.Session.Get<DataGame>("dataGame");

                foreach (PsychicMan man in dataGame.Psychics)
                {
                    man.Сurrent_guess = new Random().Next(1, 4);
                    man.Guesses.Add(man.Сurrent_guess);
                }
                HttpContext.Session.Set("dataGame", dataGame);
                return Ok(dataGame);
            }
            else
            {
                DataGame dataGame = new DataGame
                {
                    Psychics = new List<PsychicMan>
                    {
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Сurrent_guess = new Random().Next(1, 4),
                            Guesses = new List<int>(),
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        }
                    },
                    Player_Numbers = new List<int>()
                };
                foreach (PsychicMan man in dataGame.Psychics)
                {
                    //var current = man.Сurrent_guess;
                    man.Guesses.Add(man.Сurrent_guess);
                }
                HttpContext.Session.Set("dataGame", dataGame);
                return Ok(dataGame);
            }

        }
    }
}
