


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using M4Trader.ordenes.services.Entities;
using M4TraderWebApp.Entities;
using M4TraderWebApp.Helpers;
using M4TraderWebApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http;

namespace M4TraderWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        // GET: api/<I18nController>
        [HttpPost]
        public JsonResult Post([FromBody]DTOMessage dto)//(int IdUser, string type, string subType, string message)
        {

            MessageHelper.OnNewMessageHandle(new DTONewMessage()
            {
                IdUser = dto.IdUser,
                Type = dto.Type,
                SubType = dto.SubType,
                Message = dto.Message,
                Date = dto.Date

            }, _hubContext);



            return new JsonResult(new { ok = true });

        }

    }


    public class TravelLiteral
    {
        public string Token { get; set; }
    }
}
