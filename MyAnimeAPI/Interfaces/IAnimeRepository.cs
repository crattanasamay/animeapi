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

        public ActionResult DeleteAnime(int id);

        public ActionResult UpdateAnime(int id);

        public List<UserMaxRating> GetUsersMaxRating();
    }
}
