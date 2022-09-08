using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp.Views;

public partial class ActorDetailsPage : ContentPage
{
	public ActorDetailsPage(ActorViewModel actorViewModel)
	{
		InitializeComponent();
		BindingContext = actorViewModel;
	}
}