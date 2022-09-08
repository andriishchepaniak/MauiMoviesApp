using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel searchViewModel)
	{
		InitializeComponent();
		BindingContext = searchViewModel;
	}
}