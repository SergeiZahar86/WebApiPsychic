using MediatR;
using Microsoft.AspNetCore.Http;
using WebApiPsychic;

namespace Application.DataGames.Queries.GetDataGameDetails
{
    public class GetDataGameDetailsQuery : IRequest<DataGame>
    {
        public ISession Session { get; set; }
    }
}
