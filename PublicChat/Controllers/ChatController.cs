using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PublicChat.Hubs;
using PublicChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicChat.Controllers
{
    [Produces("application/json")]
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("SendNotification")]
        [HttpPost]
        [ProducesResponseType(typeof(SignalRModel), 200)]
        public IActionResult SendNotification([FromBody] NotificationDto data )
        {
            try
            {
                SignalRDto signal = new() { Notify = data.Notify, Receivers = data.Receivers, IsPrivate = data.IsPrivate };
                SignalRModel resultModel = new() { Notify = signal.Notify };
                if (signal.IsPrivate)
                {
                    foreach (var receiver in signal.Receivers)
                    {
                        var list = ChatHub.clients.Where(x => x.Key == receiver);
                        foreach (var item in list)
                        {
                            _hubContext.Clients.Client(item.Value).SendAsync("receiveSignal", resultModel);
                        }
                    }
                }
                else
                {
                    _hubContext.Clients.All.SendAsync("receiveSignal", resultModel);

                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            

           
        } 
     
        //[Route("sendMessage")]
        //[HttpPost]
        //public IActionResult SendMessage([FromBody] MessageDto msg)
        //{
        //    var list = ChatHub.clients.Where(x => x.Key == msg.reciever);
        //    foreach (var item in list)
        //    {
        //        _hubContext.Clients.Client(item.Value).SendAsync("receiveSignal", msg);
        //    }

        //    return Ok();
        //}
    }
}
