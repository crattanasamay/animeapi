using MyAnimeAPI.Interfaces;
using MyAnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MyAnimeAPI.DBContext;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using Newtonsoft.Json;

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

            var findAnime = _dbContext.Anime.ToList();

            Console.WriteLine(findAnime);

            if(findAnime == null)
            {
                return Enumerable.Empty<Anime>();
            }
            else
            {
                return findAnime;
            }


        }

        public IActionResult DeleteAnime(int id)
        {
            Anime findAnime = _dbContext.Anime.FirstOrDefault(u => u.Id == id);

            if(findAnime == null)
            {
                var result = new
                {
                    sucess = false,
                    responseText = "Id not found"
                };
                return new JsonResult(result);
            }
            else
            {
                _dbContext.Anime.Remove(findAnime);
                _dbContext.SaveChanges();
                var result = new
                {
                    sucess = true,
                    responseText = "Id of anime has been deleted"
                };
                return new JsonResult(result);

            }
        }


        public IActionResult UpdateAnime(int id, Anime anime)
        {
            using (var dbContext = _dbContext) { 
                var existingAnime = dbContext.Anime.FirstOrDefault(a => a.Id == id);
                if(existingAnime == null)
                {
                    var result = new
                    {
                        success = false,
                        responseText = "could not find anime id"
                    };
                    return new JsonResult(result);
                }
                else
                {
                    existingAnime.Name = anime.Name;
                    existingAnime.Season = anime.Season;
                    existingAnime.Summary = anime.Summary;
                    dbContext.SaveChanges();

                    var result = new
                    {
                        success = true,
                        responseText = "updated animed"
                    };
                    return new JsonResult(result);
                }
            }
            
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
