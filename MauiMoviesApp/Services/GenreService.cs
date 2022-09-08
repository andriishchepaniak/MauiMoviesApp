using MauiMoviesApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MauiMoviesApp.Services
{
    public class GenreService
    {
        private readonly HttpClient _client;
        private const string API_KEY = "04b7ea16f2db96b522caecde3ca96c36";

        public GenreService(HttpClient client)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.themoviedb.org/3/genre/movie/");
        }

        public async Task<List<Genre>> GetGenres()
        {
            var response = await _client.GetAsync($"list?api_key=" + API_KEY);

            var result = await response.Content.ReadAsStringAsync();

            var genres = JObject.Parse(result)["genres"].ToObject<List<Genre>>();

            return genres;
        }
    }
}
