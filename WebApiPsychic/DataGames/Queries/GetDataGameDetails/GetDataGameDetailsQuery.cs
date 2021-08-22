using MediatR;
using Microsoft.AspNetCore.Http;
using WebApiPsychic;

namespace WebApiPsychic.DataGames.Queries.GetDataGameDetails
{
    public class GetDataGameDetailsQuery : IRequest<DataGame>
    {
        public ISession Session { get; set; }
    }
}
