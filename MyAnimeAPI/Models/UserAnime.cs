﻿namespace MyAnimeAPI.Models
{
    public class UserAnime
    {
        public int Id { get; set; }

        public string? UserName { get; set; }
        public int AnimeId { get; set; }

        public DateTime AnimeDateAdded { get; set; }

        public double Rating { get; set; }

        public string genres { get; set; }
    }
}
