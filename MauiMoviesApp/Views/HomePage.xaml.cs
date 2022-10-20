using MauiMoviesApp.ViewModels;
using System.Runtime.CompilerServices;

namespace MauiMoviesApp.Views;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
		_homeViewModel = homeViewModel;
	}

	protected override void OnAppearing()
	{
		_homeViewModel.GetTopRatedMoviesCommand.Execute(null);
		_homeViewModel.OnAppearingCommand.Execute(null);
	}
}