using MauiMoviesApp.Views;

namespace MauiMoviesApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MoviesPage), typeof(MoviesPage));
		Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
        Routing.RegisterRoute(nameof(ActorDetailsPage), typeof(ActorDetailsPage));
    }
}
