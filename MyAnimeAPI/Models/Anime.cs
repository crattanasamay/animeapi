using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyAnimeAPI.Models
{
    public class Anime
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Season { get; set; }

        public string Summary { get; set; }


    }
}
