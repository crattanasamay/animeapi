using MyAnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using MyAnimeAPI.Repositories;
using MyAnimeAPI.DBContext;

namespace MyAnimeAPI.Interfaces
{
    public interface IAnimeRepository 
    {
        public ActionResult<Anime> GetAnime(int id);

        public IEnumerable<Anime> GetAnimes();

        public IActionResult DeleteAnime(int id);

        public IActionResult UpdateAnime(int id,Anime anime);

        public List<UserMaxRating> GetUsersMaxRating();
    }
}
