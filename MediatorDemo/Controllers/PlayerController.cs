using MediatorDemo.Features.CreatePlayer;
using MediatorDemo.Features.GetPlayerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ISender _sender;
        public PlayerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Add new Player")]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand model)
        {
            var player = await _sender.Send(model);

            return Ok(player);
        }

        [HttpGet("Get player By {Id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _sender.Send(new GetPlayerQuery(id));
            if (player is null)
            {
                return NotFound();
            }
            return Ok(player);
        }

    }
}
