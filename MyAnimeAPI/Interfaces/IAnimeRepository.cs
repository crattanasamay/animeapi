using MyAnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace MyAnimeAPI.Interfaces
{
    public interface IAnimeRepository 
    {

        public ActionResult<Anime> GetAnime(int id);

        public IEnumerable<Anime> GetAnimes();

        public ActionResult DeleteAnime(int id);

        public ActionResult UpdateAnime(int id);

    }
}
