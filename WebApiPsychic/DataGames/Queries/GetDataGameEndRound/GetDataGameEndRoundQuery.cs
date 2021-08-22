using MediatR;
using Microsoft.AspNetCore.Http;

namespace WebApiPsychic.DataGames.Queries.GetDataGameEndRound
{
    public class GetDataGameEndRoundQuery : IRequest<DataGame>
    {
        public int SecretNumber { get; set; }
        public ISession Session { get; set; }
    }
}
