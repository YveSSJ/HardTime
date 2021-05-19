using HardTime.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HardTime.Controllers
{
    [ApiController]
    [Route("clock")]
    public class ClockController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMessagesRepository _messagesRepository;

        public ClockController(IConfiguration configuration, IMessagesRepository messagesRepository)
        {
            _configuration = configuration;
            _messagesRepository = messagesRepository;

        }
        [HttpGet]
        [Route("getMessage")]
        public IActionResult GetMessage()
        {
            var messageDto = new MessageDto { Author = "Secret", Content = "I don't know" };
            return Ok(messageDto);
        }

        [HttpPost]
        [Route("sendMessage")]
        public IActionResult SendMessage([FromBody] MessageDto messageDto)
        {
            var messageEntity = new MessageEntity { Content = messageDto.Content };
            var result = _messagesRepository.Add(messageEntity);
            if (result) { return Ok(messageDto); }
            return NotFound();
        }
    }
}
