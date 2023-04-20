using Microsoft.AspNetCore.Mvc;
using MyAnimeAPI.Authentication;
using MyAnimeAPI.Interfaces;
using MyAnimeAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MyAnimeAPI.Controllers
{
    [ApiController]

    [Route("[controller]/[action]")]

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
            _anime.GetUsersMaxRating();
            return _anime.GetAnimes();
        }

       


        [HttpGet("{id}")]
        public ActionResult<Anime> GetAnime(int id)
        {

            return _anime.GetAnime(id);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IActionResult DeleteAnime(int id)
        {
            return _anime.DeleteAnime(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnime(int id, [FromBody,Required]Anime anime)
        {
            var updateAnime = _anime.UpdateAnime(id, anime);
            return updateAnime;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public List<UserMaxRating> GetUserMaxRating()
        {
            return _anime.GetUsersMaxRating();
        }


      






    }
}
