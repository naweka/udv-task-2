using Microsoft.AspNetCore.Mvc;
using KolodAPI.DeckManager;
using System.Xml.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using KolodAPI.Models;

namespace KolodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckManagerController : ControllerBase
    {
        private readonly ILogger<DeckManagerController> logger;
        private readonly IDeckManager deckManager;

        private readonly JsonSerializerSettings jsonSerializerSettings =
            new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

        public DeckManagerController(
            ILogger<DeckManagerController> logger,
            IDeckManager deckManager)
        {
            this.logger = logger;
            this.deckManager = deckManager;
        }

        [HttpPost("{name}", Name = "CreateDeck")]
        public async Task<IActionResult> CreateDeck(string name)
        {
            try
            {
                deckManager.CreateDeck(name);
                
                logger.LogInformation($"Deck '{name}' created successfully");
                return Ok($"Deck '{name}' created successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "RemoveDeck")]
        public async Task<IActionResult> RemoveDeck(string name)
        {
            try
            {
                deckManager.RemoveDeck(name);

                logger.LogInformation($"Deck '{name}' removed successfully");
                return Ok($"Deck '{name}' removed successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "GetDeckNames")]
        public async Task<IActionResult> GetDeckNames()
        {
            try
            {
                var names = deckManager.GetDeckNames();
                var json = JsonConvert.SerializeObject(names, jsonSerializerSettings);

                logger.LogInformation("Sending all deck names");
                return Ok(json);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{name}/shuffle", Name = "ShuffleDeck")]
        public async Task<IActionResult> ShuffleDeck(string name)
        {
            try
            {
                deckManager.ShuffleDeck(name);

                logger.LogInformation($"Deck '{name}' shuffled successfully");
                return Ok($"Deck '{name}' shuffled successfully");
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}", Name = "GetDeck")]
        public async Task<IActionResult> GetDeck(string name)
        {
            try
            {
                var deck = deckManager.GetDeck(name);
                var json = JsonConvert.SerializeObject(
                    deck.Cards, 
                    jsonSerializerSettings);

                logger.LogInformation($"Sending deck '{name}'");
                return Ok(json);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
