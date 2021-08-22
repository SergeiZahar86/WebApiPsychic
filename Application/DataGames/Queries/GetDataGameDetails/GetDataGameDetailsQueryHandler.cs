using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiPsychic;

namespace Application.DataGames.Queries.GetDataGameDetails
{
    public class GetDataGameDetailsQueryHandler 
        : IRequestHandler<GetDataGameDetailsQuery, DataGame>
    {

        public Task<DataGame> Handle(GetDataGameDetailsQuery request,
                                     CancellationToken cancellationToken)
        {
            if (request.Session.Keys.Contains("dataGame"))
            {
                DataGame dataGame = request.Session.Get<DataGame>("dataGame");

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
                    //var current = man.Сurrent_guess;
                    man.Guesses.Add(man.Сurrent_guess);
                }
                HttpContext.Session.Set("dataGame", dataGame);
                var user = HttpContext.User;
                return Ok(dataGame);
            }
        }
    }
}
