using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using MauiMoviesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        MovieService movieService;
        ActorService actorService;
        public ICommand GetPopularMoviesCommand { get; set; }
        public ICommand GetTopRatedMoviesCommand { get; set; }
        public ICommand GetUpcomingMoviesCommand { get; set; }

        public ICommand GoToPopularMoviesCommand { get; set; }
        public ICommand GoToMoviesCommand { get; set; }
        public ICommand GoToDetailsCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }

        public ObservableCollection<Movie> PopularMovies { get; set; }
        public ObservableCollection<Movie> TopRatedMovies { get; set; }
        public ObservableCollection<Movie> UpcomingMovies { get; set; }

        public HomeViewModel(MovieService movieService, ActorService actorService)
        {
            IsBusy = true;

            this.movieService = movieService;
            this.actorService = actorService;

            PopularMovies = new ObservableCollection<Movie>();
            TopRatedMovies = new ObservableCollection<Movie>();
            UpcomingMovies = new ObservableCollection<Movie>();

            GetPopularMoviesCommand = new Command(async () => await GetPopularMovies());
            GetTopRatedMoviesCommand = new Command(async () => await GetTopRatedMovies());
            GetUpcomingMoviesCommand = new Command(async () => await GetLatestMovies());
            GoToDetailsCommand = new Command(async (movieId) => await GoToDetails((int)movieId));
            OnAppearingCommand = new Command(() => OnAppearing());

            //GetPopularMoviesCommand.Execute(null);
            //GetTopRatedMoviesCommand.Execute(null);
            //GetUpcomingMoviesCommand.Execute(null);


            GoToMoviesCommand = new Command<string>(async (category) => await GoToMovies(category));
            IsBusy = false;
        }

        public void ChangeIsLoading()
        {
            IsBusy = !IsBusy;
        }

        async Task GetPopularMovies()
        {
            IsBusy = true;

            if (PopularMovies.Count != 0)
                PopularMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetPopularMovies();
            var movies = await movieService.GetMovies(MovieCategories.Popular);

            foreach (var movie in movies)
            {
                PopularMovies.Add(movie);
            }

            IsBusy = false;
        }

        async Task GetTopRatedMovies()
        {
            IsBusy = true;

            if (TopRatedMovies.Count != 0)
                TopRatedMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetTopRatedMovies();
            var movies = await movieService.GetMovies(MovieCategories.TopRated);

            foreach (var movie in movies)
            {
                TopRatedMovies.Add(movie);
            }

            IsBusy = false;
        }

        async Task GetLatestMovies()
        {
            IsBusy = true;

            if (UpcomingMovies.Count != 0)
                UpcomingMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetLatestMovies();
            var movies = await movieService.GetMovies(MovieCategories.Upcoming);

            foreach (var movie in movies)
            {
                UpcomingMovies.Add(movie);
            }

            IsBusy = false;
        }

        async Task GoToMovies(string category)
        {
            await Shell.Current.GoToAsync($"{nameof(MoviesPage)}?category={category}", true);
        }

        async Task GoToDetails(int movieId)
{
            await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}?movieId={movieId}", true);
        }

        public void OnAppearing()
        {
            GetPopularMoviesCommand.Execute(null);
            GetTopRatedMoviesCommand.Execute(null);
            GetUpcomingMoviesCommand.Execute(null);
        }
    }
}
