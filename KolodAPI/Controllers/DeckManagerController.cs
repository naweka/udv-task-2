using Microsoft.AspNetCore.Mvc;
using KolodAPI.DeckManager;
using System.Xml.Linq;

namespace KolodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckManagerController : ControllerBase
    {
        private readonly ILogger<DeckManagerController> logger;
        private readonly IDeckManager deckManager;

        public DeckManagerController(
            ILogger<DeckManagerController> logger,
            IDeckManager deckManager)
        {
            this.logger = logger;
            this.deckManager = deckManager;
        }

        [HttpPost("{name}", Name = "CreateDeck")]
        public IActionResult CreateDeck(string name)
        {
            try
            {
                deckManager.CreateDeck(name);
                return Ok($"Deck '{name}' created successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "RemoveDeck")]
        public IActionResult RemoveDeck(string name)
        {
            try
            {
                deckManager.RemoveDeck(name);
                return Ok($"Deck '{name}' removed successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "GetDeckNames")]
        public IActionResult GetDeckNames()
        {
            try
            {
                var names = deckManager.GetDeckNames();
                return Ok(names);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{name}/shuffle", Name = "ShuffleDeck")]
        public IActionResult ShuffleDeck(string name)
        {
            try
            {
                deckManager.ShuffleDeck(name);
                return Ok($"Deck '{name}' shuffled successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}", Name = "GetDeck")]
        public IActionResult GetDeck(string name)
        {
            try
            {
                var deck = deckManager.GetDeck(name);
                return Ok(deck);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
