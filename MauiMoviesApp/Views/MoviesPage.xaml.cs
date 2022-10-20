using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp.Views;

public partial class MoviesPage : ContentPage
{
	MoviesViewModel _moviesViewModel;

    public MoviesPage(MoviesViewModel moviesViewModel)
	{
		InitializeComponent();

		_moviesViewModel = moviesViewModel;
		BindingContext = _moviesViewModel;
	}
}