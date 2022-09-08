using MauiMoviesApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MauiMoviesApp.Services
{
    public class ActorService
    {
        private readonly HttpClient _client;
        private const string API_KEY = "04b7ea16f2db96b522caecde3ca96c36";

        public ActorService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        }


        public async Task<List<Actor>> GetCast(int movieId)
        {
            var response = await _client.GetAsync($"movie/{movieId}/credits?api_key=" + API_KEY);

            var result = await response.Content.ReadAsStringAsync();

            var cast = JObject.Parse(result)["cast"].ToObject<List<Actor>>();

            foreach (var actor in cast)
            {
                actor.Profile_Path = "https://image.tmdb.org/t/p/original" + actor.Profile_Path;
            }

            return cast;
        }

        public async Task<Actor> GetActorDetails(int actorId)
        {
            var response = await _client.GetAsync($"person/{actorId}?api_key=" + API_KEY);

            var result = await response.Content.ReadAsStringAsync();

            var actor = JObject.Parse(result).ToObject<Actor>();

            actor.Profile_Path = "https://image.tmdb.org/t/p/original" + actor.Profile_Path;

            return actor;
        }

        public async Task<List<Movie>> GetActorMovies(int actorId)
        {
            var response = await _client.GetAsync($"person/{actorId}/movie_credits?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var movies = JObject.Parse(result)["cast"].ToObject<List<Movie>>();

            foreach (var movie in movies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return movies
                .OrderByDescending(m=>m.Vote_Average)
                .ToList();
        }

        public async Task<List<Actor>> SearchActor(string search)
        {
            var response = await _client.GetAsync($"search/person?api_key=" + API_KEY + $"&query={search}&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var actors = JObject.Parse(result)["results"].ToObject<List<Actor>>();

            foreach (var actor in actors)
            {
                actor.Profile_Path = "https://image.tmdb.org/t/p/original" + actor.Profile_Path;
            }

            return actors;
        }
    }
}
