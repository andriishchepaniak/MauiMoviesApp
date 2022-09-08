using System;
using System.Collections.Generic;
using System.Text;

namespace MauiMoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster_Path { get; set; }
        public string Original_Language { get; set; }
        public string Overview { get; set; }
        public string Popularity { get; set; }
        public string Vote_Average { get; set; }
    }
}
