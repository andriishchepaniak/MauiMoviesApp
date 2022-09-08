using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using MauiMoviesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private MovieService _movieService;
        private ActorService _actorService;
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {

                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Actor> Actors { get; set; }

        public ICommand GetSearchedMoviesCommand { get; set; }
        public ICommand GoToDetailsCommand { get; set; }

        public SearchViewModel(MovieService movieService, ActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;

            Movies = new ObservableCollection<Movie>();
            Actors = new ObservableCollection<Actor>();

            GetSearchedMoviesCommand = new Command(async () => await Search());
            GoToDetailsCommand = new Command<int>(async (movieId) => await GoToMovieDetails(movieId));
        }

        async Task GetSearchedMovies()
        {
            var movies = await _movieService.GetSearchedMovies(SearchText);

            if (Movies.Count != 0)
            {
                Movies.Clear();
            }

            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
            //SearchText = "";
        }

        async Task GetSearchedActors()
        {
            var actors = await _actorService.SearchActor(SearchText);

            if (Actors.Count != 0)
            {
                Actors.Clear();
            }

            foreach (var actor in actors)
            {
                Actors.Add(actor);
            }
            SearchText = "";
        }

        async Task Search()
        {
            await GetSearchedMovies();
            await GetSearchedActors();
        }


        async static Task GoToMovieDetails(int movieId)
        {
            await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}?movieId={movieId}", true);
        }
    }
}
