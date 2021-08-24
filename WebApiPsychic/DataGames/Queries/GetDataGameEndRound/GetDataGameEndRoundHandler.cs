using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiPsychic.Common.Exception;

namespace WebApiPsychic.DataGames.Queries.GetDataGameEndRound
{
    public class GetDataGameEndRoundHandler : IRequestHandler<GetDataGameEndRoundQuery, DataGame>
    {
        public Task<DataGame> Handle(GetDataGameEndRoundQuery request,
                                     CancellationToken cancellationToken)
        {
            Task<DataGame> TaskDataGame = new Task<DataGame>(() =>
            {
                if (request.SecretNumber < 1 || request.SecretNumber > 4)
                {
                    throw new BadRequestException(request.SecretNumber);
                }
                DataGame dataGame = request.Session.Get<DataGame>("dataGame");
                if (dataGame.Psychics[0].Сurrent_guess != null)
                {
                    foreach (PsychicMan man in dataGame.Psychics)
                    {
                        if (man.Сurrent_guess == request.SecretNumber)
                            man.Authenticity++;
                        else man.Authenticity--;

                        man.Сurrent_guess = null;
                    }
                    dataGame.Player_Numbers.Add(request.SecretNumber);
                    request.Session.Set("dataGame", dataGame);
                }
                return dataGame;
            });
            TaskDataGame.Start();
            return TaskDataGame;
        }
    }
}
