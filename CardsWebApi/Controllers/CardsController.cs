using CardsWebApi.Data;
using CardsWebApi.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly ApiDbContext _context;
        public CardsController(
            ILogger<CardsController> logger,
            ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "list")]
        public async Task<IActionResult> Get()
        {
            var drivers = await _context.Cards.ToListAsync();
            return Ok(drivers);
        }

        [HttpPost(Name = "generate")]
        public async Task<IActionResult> GenerateCard()
        {
            var rnd = new Random();
            var card = new Card()
            {
                HolderId = rnd.Next(100000),
                IbanAccount = "GE56TB1453287634876",
                HolderLabel = "Name Lastname"
            };

            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
