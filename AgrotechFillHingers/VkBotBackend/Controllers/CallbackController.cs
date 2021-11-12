using AgrotechFillHingers.VkBotBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;

namespace AgrotechFillHingers.VkBotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVkApi _vkApi;

        public CallbackController(IVkApi vkApi, IConfiguration configuration)
        {
            _vkApi = vkApi;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Callback([FromBody] MessageModel message)
        {
            switch (message.Type)
            {
                case "confirmation":
                    return Ok(_configuration["VkConfig:Confirmation"]);

                case "message_new":
                    //var msg = Message.FromJson(new VkResponse(updates.Object));
                    var msg = message.Object.Message;
                    _vkApi.Messages.Send(new MessagesSendParams()
                    {
                        RandomId = Environment.TickCount,
                        PeerId = msg.PeerId,
                        Message = msg.Text
                    });
                    break;
            }

            return Ok("ok");
        }
    }
}
