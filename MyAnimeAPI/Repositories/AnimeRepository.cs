using MyAnimeAPI.Interfaces;
using MyAnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MyAnimeAPI.DBContext;

namespace MyAnimeAPI.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        MyDbContext _dbContext;
        public AnimeRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<Anime> GetAnime(int id)
        {
            var animeList = GetAnimes();

            var findAnime = animeList.Where(anime => anime.Id == id).SingleOrDefault();

            var animeObj = _dbContext.Anime.Where(u => u.Id == id);
            Console.WriteLine(animeObj);


            if(animeObj == null)
            {
                return new NotFoundResult();
            }
            return findAnime;

        }

        public IEnumerable<Anime> GetAnimes()
        {
            return Enumerable.Range(1, 2).Select(index => new Anime
            {
                Id = index,
                Name = "Engage Kiss",
                Season = "Fall",
                Summary = "Hot and Spicy",
            })
           .ToList();

        }

        public ActionResult DeleteAnime(int id)
        {
            return new NotFoundResult();
        }


        public ActionResult UpdateAnime(int id)
        {

            return new NotFoundResult();
        }
    }
}
