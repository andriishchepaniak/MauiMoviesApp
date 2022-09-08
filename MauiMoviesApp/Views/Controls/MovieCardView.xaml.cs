using MauiMoviesApp.Services;
using System.Windows.Input;

namespace MauiMoviesApp.Views.Controls;

public partial class MovieCardView : ContentView
{
    public static readonly BindableProperty MovieIdProperty = BindableProperty.Create(
           "MovieId",
           typeof(int),
           typeof(MovieCardView),
           0
       );

    public static readonly BindableProperty Poster_PathProperty = BindableProperty.Create(
        "Poster_Path",
        typeof(string),
        typeof(MovieCardView),
        string.Empty
    );

    public static readonly BindableProperty Vote_AverageProperty = BindableProperty.Create(
        "Vote_Average",
        typeof(string),
        typeof(MovieCardView),
        string.Empty
    );

    public int MovieId
    {
        get => (int)GetValue(MovieIdProperty);
        set => SetValue(MovieIdProperty, value);
    }

    public string Poster_Path
    {
        get => (string)GetValue(Poster_PathProperty);
        set => SetValue(Poster_PathProperty, value);
    }

    public string Vote_Average
    {
        get => (string)GetValue(Vote_AverageProperty);
        set => SetValue(Vote_AverageProperty, value);
    }

    public ICommand GoToDetailsCommand { get; set; }
    public MovieCardView()
	{
        GoToDetailsCommand = new Command(async () => await GoToDetails(MovieId));
		InitializeComponent();
	}

    public async Task GoToDetails(int movieId)
    {
        //ActorService actorService = new ActorService();
        //MovieService movieService = new MovieService();

        //var movie = await movieService.GetMovieById(MovieId);
        //var videos = await movieService.GetMovieVideos(MovieId);

        //var video = videos.First();
        //var cast = await actorService.GetCast(MovieId);

        //var similarMovies = await movieService.GetSimilarMovies(movieId);
        //var recommendationMovies = await movieService.GetRecomendationMovies(movieId);


        //await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}", true, 
        //    new Dictionary<string, object>
        //    {
        //        {nameof(movie), movie },
        //        {nameof(movieId), movieId },
        //        {nameof(video), video },
        //        {nameof(cast), cast },
        //        {nameof(similarMovies), similarMovies },
        //        {nameof(recommendationMovies), recommendationMovies }
        //    });
        
        await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}?movieId={MovieId}", true);
    }

}