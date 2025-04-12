using MediatorDemo.Features.CreatePlayer;
using MediatorDemo.Features.GetAllPlayers;
using MediatorDemo.Features.GetPlayerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MediatorDemo.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ISender _sender;
        private readonly IMemoryCache _memoryCach;
        public PlayerController(ISender sender , IMemoryCache memoryCash)
        {
            _sender = sender;
            _memoryCach = memoryCash;
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
        [HttpGet("Get All players")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var cashKey = "allPlayers";
            if (!_memoryCach.TryGetValue(cashKey, out var result))
            {
                result = await _sender.Send(new GetAllPlayersQuery("Ahmed"));
                _memoryCach.Set(cashKey, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddHours(6),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                });
            }

            return Ok(result);
        }
    }
}
