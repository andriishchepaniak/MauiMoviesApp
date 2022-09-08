using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using MauiMoviesApp.Views;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class MoviesViewModel : BaseViewModel, IQueryAttributable
    {
        MovieService _movieService;
        public MoviesViewModel(MovieService movieService)
        {
            _movieService = movieService;

            GoToDetailsCommand = new Command<int>(async (movieId) => await GoToMovieDetails(movieId));
            Movies = new ObservableCollection<Movie>();
        }

        public ICommand GoToDetailsCommand { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        //public async void ApplyQueryAttributes(IDictionary<string, string> query)
        //{
        //    var category = HttpUtility.UrlDecode(query["category"].ToString());

        //    var movies = await _movieService.GetMovies(category);

        //    if (Movies.Count != 0)
        //        Movies.Clear();

        //    foreach (var movie in movies)
        //    {
        //        Movies.Add(movie);
        //    }

        //    OnPropertyChanged("Movies");
        //}


        async static Task GoToMovieDetails(int movieId)
        {
            await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}?movieId={movieId}", true);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var category = HttpUtility.UrlDecode(query["category"].ToString());

            var movies = await _movieService.GetMovies(category);

            if (Movies.Count != 0)
                Movies.Clear();

            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
        }

        public void OnAppearing()
        {
            var a = 1;
        }
    }
}
