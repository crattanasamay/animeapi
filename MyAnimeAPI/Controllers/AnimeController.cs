using Microsoft.AspNetCore.Mvc;
using MyAnimeAPI.Authentication;
using MyAnimeAPI.Interfaces;
using MyAnimeAPI.Models;

namespace MyAnimeAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]

    public class AnimeController : ControllerBase
    {

        private readonly ILogger<AnimeController> _logger;
        private readonly IAnimeRepository _anime;

        public AnimeController(ILogger<AnimeController> logger, IAnimeRepository anime)
        {
            _logger = logger;
            _anime = anime;

        }

        [HttpGet]
        public IEnumerable<Anime> GetAnimes()
        {
            return _anime.GetAnimes();
        }

        [HttpGet("{id}")]
        public ActionResult<Anime> GetAnime(int id)
        {

            return _anime.GetAnime(id);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public ActionResult DeleteAnime(int id)
        {
            return Ok();
        }

        [HttpPost("{id}")]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public ActionResult UpdateAnime(int id)
        {
            return Ok();
        }
      
     
      
    }
}
