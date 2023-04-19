using System.Threading.Tasks;
using BadAdvisor.Mvc.Data;
using BadAdvisor.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadAdvisor.Mvc.Controllers
{
    [Route("messages")]
    public class MessagesController : Controller
    {

        private readonly IMessagesRepository _messagesRepository;

        public MessagesController(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            var message = _messagesRepository.GetNext();

            return new JsonResult(new MessageModel
            {
                Text = message.Text,
            });
        }
    }
}