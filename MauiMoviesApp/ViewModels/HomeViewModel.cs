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
        public ICommand GetPopularMoviesCommand { get; set; }
        public ICommand GetTopRatedMoviesCommand { get; set; }
        public ICommand GetUpcomingMoviesCommand { get; set; }

        public ICommand GoToPopularMoviesCommand { get; set; }
        public ICommand GoToSearchPageCommand { get; set; }
        public ICommand GoToMoviesCommand { get; set; }

        public ObservableCollection<Movie> PopularMovies { get; set; }
        public ObservableCollection<Movie> TopRatedMovies { get; set; }
        public ObservableCollection<Movie> UpcomingMovies { get; set; }

        public HomeViewModel(MovieService movieService)
        {
            IsLoading = true;

            this.movieService = movieService;

            PopularMovies = new ObservableCollection<Movie>();
            TopRatedMovies = new ObservableCollection<Movie>();
            UpcomingMovies = new ObservableCollection<Movie>();

            GetPopularMoviesCommand = new Command(async () => await GetPopularMovies());
            GetTopRatedMoviesCommand = new Command(async () => await GetTopRatedMovies());
            GetUpcomingMoviesCommand = new Command(async () => await GetLatestMovies());


            GetPopularMoviesCommand.Execute(null);
            GetTopRatedMoviesCommand.Execute(null);
            GetUpcomingMoviesCommand.Execute(null);


            GoToSearchPageCommand = new Command(async () => await GoToSearchPage());
            GoToMoviesCommand = new Command<string>(async (category) => await GoToMovies(category));
            IsLoading = false;
        }

        public void ChangeIsLoading()
        {
            IsLoading = !IsLoading;
        }

        async Task GetPopularMovies()
        {
            IsLoading = true;

            if (PopularMovies.Count != 0)
                PopularMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetPopularMovies();
            var movies = await movieService.GetMovies(MovieCategories.Popular);

            foreach (var movie in movies)
            {
                PopularMovies.Add(movie);
            }

            IsLoading = false;
        }

        async Task GetTopRatedMovies()
        {
            IsLoading = true;

            if (TopRatedMovies.Count != 0)
                TopRatedMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetTopRatedMovies();
            var movies = await movieService.GetMovies(MovieCategories.TopRated);

            foreach (var movie in movies)
            {
                TopRatedMovies.Add(movie);
            }

            IsLoading = false;
        }

        async Task GetLatestMovies()
        {
            IsLoading = true;

            if (UpcomingMovies.Count != 0)
                UpcomingMovies = new ObservableCollection<Movie>();

            //var movies = await movieService.GetLatestMovies();
            var movies = await movieService.GetMovies(MovieCategories.Upcoming);

            foreach (var movie in movies)
            {
                UpcomingMovies.Add(movie);
            }

            IsLoading = false;
        }

        async static Task GoToMovies(string category)
        {
            await Shell.Current.GoToAsync($"{nameof(MoviesPage)}?category={category}", true);
        }

        async static Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync($"{nameof(SearchPage)}", true);
        }
    }
}
