using MyAnimeAPI.Interfaces;
using MyAnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MyAnimeAPI.DBContext;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;

namespace MyAnimeAPI.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AnimeRepository(MyDbContext dbContext,IConfiguration configuration)
        {
            _configuration = configuration; 
            _dbContext = dbContext;
        }
        public ActionResult<Anime> GetAnime(int id)
        {
            var animeList = GetAnimes();

            var findAnime = animeList.Where(anime => anime.Id == id).SingleOrDefault();

            var animeObj = _dbContext.Anime.Where(u => u.Id == id).ToList();
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

        public List<UserMaxRating> GetUsersMaxRating()
        {
            try
            {

                string connString = _configuration["ConnectionStringAzure"];
                using (var con = new SqlConnection(connString))
                {
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "spGetUserMaxRating";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    var result = cmd.ExecuteReader();
                    var b = new List<UserMaxRating>();
                    while (result.Read())
                    {
                        var r = new UserMaxRating();
                        r.UserName = result.GetString(0);
                        if (!result.IsDBNull(1))
                        {
                            r.Rating = result.GetDouble(1);
                        }
                        b.Add(r);
                    }
                    return b;

                }
            } catch (Exception ex) {

                var r = new List<UserMaxRating>();
                return r;
            }
           
        }
    }
}
