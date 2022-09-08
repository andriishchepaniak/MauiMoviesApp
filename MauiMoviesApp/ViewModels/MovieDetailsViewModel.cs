using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using MauiMoviesApp.Views;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private Movie movie;
        private Video video;
        public ObservableCollection<Actor> Cast { get; set; } = new();
        public ObservableCollection<Movie> SimilarMovies { get; set; } = new();
        public ObservableCollection<Movie> RecomendationMovies { get; set; } = new();
        public Movie Movie
        {
            get => movie;
            set
            {
                if (movie == value)
                {
                    return;
                }
                movie = value;
                OnPropertyChanged(nameof(Movie));
            }
        }

        public Video Video
        {
            get => video;
            set
            {
                if (video == value)
                {
                    return;
                }
                video = value;
                OnPropertyChanged(nameof(Video));
            }
        }

        public ICommand WatchTrailerCommand { get; set; }

        //public async void ApplyQueryAttributes(IDictionary<string, string> query)
        //{
        //    var movieId = Convert.ToInt32(HttpUtility.UrlDecode(query["movieId"].ToString()));
        //    Movie = await _movieService.GetMovieById(movieId);
        //    //TODO with NotifyTaskCompletion
        //    var videos = await _movieService.GetMovieVideos(movieId);
        //    Video = videos.First();
        //    var cast = await _actorService.GetCast(movieId);
        //    foreach (var actor in cast)
        //    {
        //        Cast.Add(actor);
        //    }
        //    var similarMovies = await _movieService.GetSimilarMovies(movieId);
        //    foreach (var movie in similarMovies)
        //    {
        //        SimilarMovies.Add(movie);
        //    }
        //    var recommendationMovies = await _movieService.GetRecomendationMovies(movieId);
        //    foreach (var movie in recommendationMovies)
        //    {
        //        RecomendationMovies.Add(movie);
        //    }
        //}



        MovieService _movieService;
        ActorService _actorService;


        public MovieDetailsViewModel(MovieService movieService, ActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;

            WatchTrailerCommand = new Command<string>(async (url) => await Browser.OpenAsync(url));
        }

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    Movie = query["movie"] as Movie;

        //    Video = query["video"] as Video;

        //    var cast = query["cast"] as List<Actor>;

        //    if (Cast.Count != 0)
        //        Cast.Clear();
        //    foreach (var actor in cast)
        //    {
        //        Cast.Add(actor);
        //    }

        //    var similarMovies = query["similarMovies"] as List<Movie>;

        //    if (SimilarMovies.Count != 0)
        //        SimilarMovies.Clear();
        //    foreach (var movie in similarMovies)
        //    {
        //        SimilarMovies.Add(movie);
        //    }

        //    var recommendationMovies = query["recommendationMovies"] as List<Movie>;

        //    if (RecomendationMovies.Count != 0)
        //        RecomendationMovies.Clear();
        //    foreach (var movie in recommendationMovies)
        //    {
        //        RecomendationMovies.Add(movie);
        //    }
        //}
        
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            IsLoading = true;
            var movieId = Convert.ToInt32(query["movieId"] as string);

            Movie = await _movieService.GetMovieById(movieId);

            var videos = await _movieService.GetMovieVideos(movieId);
            Video = videos.FirstOrDefault();

            var cast = await _actorService.GetCast(movieId);

            if (Cast.Count != 0)
                Cast.Clear();
            foreach (var actor in cast)
            {
                Cast.Add(actor);
            }

            var similarMovies = await _movieService.GetSimilarMovies(movieId);

            if (SimilarMovies.Count != 0)
                SimilarMovies.Clear();
            foreach (var movie in similarMovies)
            {
                SimilarMovies.Add(movie);
            }

            var recommendationMovies = await _movieService.GetRecomendationMovies(movieId);

            if (RecomendationMovies.Count != 0)
                RecomendationMovies.Clear();
            foreach (var movie in recommendationMovies)
            {
                RecomendationMovies.Add(movie);
            }

            IsLoading = false;
        }
    }
}
