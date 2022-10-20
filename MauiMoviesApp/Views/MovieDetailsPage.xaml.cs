using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp.Views;

public partial class MovieDetailsPage : ContentPage
{
	private readonly MovieDetailsViewModel _movieDetailsViewModel;
	public MovieDetailsPage(MovieDetailsViewModel movieDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = movieDetailsViewModel;
		_movieDetailsViewModel = movieDetailsViewModel;
    }

	protected override void OnAppearing()
	{
		_movieDetailsViewModel.OnAppearingCommand.Execute(null);
	}
}