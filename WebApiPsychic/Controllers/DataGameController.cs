using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiPsychic.DataGames.Queries.GetDataGameDetails;
using WebApiPsychic.DataGames.Queries.GetDataGameEndRound;
using Notes.WebApi.Controllers;
using System.Net.Mime;

namespace WebApiPsychic.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("api/datagame")]
    public class DataGameController : BaseController
    {
        private readonly ILogger<DataGameController> _logger;
        public DataGameController(ILogger<DataGameController> logger)
        {
            _logger = logger;
        }

        //[EnableCors("allowAll")]
        /// <summary>
        /// Получение предполагаемых чисел в начале раунда от экстрасенсов
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / StartGame
        /// </remarks>
        /// <returns>Returns DataGame</returns>
        /// <response code="200">Удачное выполнение запроса</response>
        /// <response code="400">Ошибка во время выполнения</response>
        [HttpGet]
        [Route("startgame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DataGame>> StartGame()
        {
            ISession session = HttpContext.Session;
            GetDataGameDetailsQuery getDataGame = new()
            {
                Session = session
            };
            var dg = await Mediator.Send(getDataGame);
            return Ok(dg);
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
        /// <response code="200">Удачное выполнение запроса</response>
        /// <response code="400">Переданное значение не в рамках
        /// допустимого диапазона</response>
        [HttpPost]
        [Route("endround")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DataGame>> EndRound([FromBody]int secretNumber)
        {
            ISession session = HttpContext.Session;
            GetDataGameEndRoundQuery gameCommand = new()
            {
                SecretNumber = secretNumber,
                Session = session
            };
            var dg = await Mediator.Send(gameCommand);
            return Ok(dg);
        }
    }
}
