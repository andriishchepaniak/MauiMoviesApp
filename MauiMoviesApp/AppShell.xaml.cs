using MauiMoviesApp.ViewModels;
using MauiMoviesApp.Views;
using System.Windows.Input;

namespace MauiMoviesApp;

public partial class AppShell : Shell
{

    public AppShell(AppShellViewModel appShellViewModel)
    {
        InitializeComponent();

        BindingContext = appShellViewModel;
        Routing.RegisterRoute(nameof(MoviesPage), typeof(MoviesPage));
        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
        Routing.RegisterRoute(nameof(ActorDetailsPage), typeof(ActorDetailsPage));
    }

   
}
