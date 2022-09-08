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

	protected override void OnAppearing()
	{
		base.OnAppearing();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		_moviesViewModel.OnAppearing();
    }
}