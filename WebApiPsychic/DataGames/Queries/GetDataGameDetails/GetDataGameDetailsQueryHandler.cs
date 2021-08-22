using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiPsychic.DataGames.Queries.GetDataGameDetails
{
    public class GetDataGameDetailsQueryHandler
        : IRequestHandler<GetDataGameDetailsQuery, DataGame>
    {
        public Task<DataGame> Handle(GetDataGameDetailsQuery request,
                                     CancellationToken cancellationToken)
        {
            if (request.Session.Keys.Contains("dataGame"))
            {
                Task<DataGame> TaskDataGame = new Task<DataGame>(() =>
                {
                    DataGame dataGame = request.Session.Get<DataGame>("dataGame");
                    foreach (PsychicMan man in dataGame.Psychics)
                    {
                        man.Сurrent_guess = new Random().Next(1, 4);
                        man.Guesses.Add(man.Сurrent_guess);
                    }
                    request.Session.Set("dataGame", dataGame);
                    return dataGame;
                });
                TaskDataGame.Start();
                return TaskDataGame;
            }
            else
            {
                Task<DataGame> TaskDataGame = new Task<DataGame>(() =>
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
                            Guesses = new List<int?>(),
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int?>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        },
                        new PsychicMan
                        {
                            Name = "Tom",
                            Authenticity = 0,
                            Guesses = new List<int?>(),
                            Сurrent_guess = new Random().Next(1, 4)
                        }
                    },
                        Player_Numbers = new List<int>()
                    };
                    foreach (PsychicMan man in dataGame.Psychics)
                    {
                        man.Guesses.Add(man.Сurrent_guess);
                    }
                    request.Session.Set("dataGame", dataGame);
                    return dataGame;
                });
                TaskDataGame.Start();
                return TaskDataGame;
            }
        }
    }
}
