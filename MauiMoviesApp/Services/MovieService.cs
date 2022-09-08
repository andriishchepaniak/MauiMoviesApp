using MauiMoviesApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MauiMoviesApp.Services
{
    public class MovieService
    {
        HttpClient _client;
        private const string API_KEY = "04b7ea16f2db96b522caecde3ca96c36";



        public MovieService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        }

        public async Task<List<Movie>> GetMovies(string category)
        {
            var response = await _client.GetAsync($"movie/{category}?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<List<Movie>> GetPopularMovies()
        {
            var response = await _client.GetAsync($"movie/popular?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<List<Movie>> GetTopRatedMovies()
        {
            var response = await _client.GetAsync("movie/top_rated?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<List<Movie>> GetLatestMovies()
        {
            var response = await _client.GetAsync("movie/upcoming?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            var response = await _client.GetAsync($"movie/{movieId}?api_key=" + API_KEY);

            var result = await response.Content.ReadAsStringAsync();

            var movie = JObject.Parse(result).ToObject<Movie>();
            movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;

            return movie;
        }

        public async Task<List<Movie>> GetSimilarMovies(int movieId)
        {
            var response = await _client.GetAsync($"movie/{movieId}/similar?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<List<Movie>> GetRecomendationMovies(int movieId)
        {
            var response = await _client.GetAsync($"movie/{movieId}/recommendations?api_key=" + API_KEY + "&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var popularMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in popularMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return popularMovies;
        }

        public async Task<List<Movie>> GetSearchedMovies(string search)
        {
            var response = await _client.GetAsync($"search/movie?api_key=" + API_KEY + $"&query={search}&page=1");

            var result = await response.Content.ReadAsStringAsync();

            var searchedMovies = JObject.Parse(result)["results"].ToObject<List<Movie>>();

            foreach (var movie in searchedMovies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/original" + movie.Poster_Path;
            }

            return searchedMovies;
        }

        public async Task<List<Video>> GetMovieVideos(int movieId)
        {
            var response = await _client.GetAsync($"movie/{movieId}/videos?api_key=" + API_KEY);

            var result = await response.Content.ReadAsStringAsync();

            var videos = JObject.Parse(result)["results"].ToObject<List<Video>>();

            foreach (var video in videos)
            {
                video.Key = "https://www.youtube.com/watch?v=" + video.Key;
            }

            return videos;
        }
    }
}
