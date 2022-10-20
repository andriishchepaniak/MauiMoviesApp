using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp.Views;

public partial class ActorDetailsPage : ContentPage
{
	ActorViewModel _actorViewModel;

    public ActorDetailsPage(ActorViewModel actorViewModel)
	{
		InitializeComponent();
		BindingContext = actorViewModel;
		_actorViewModel = actorViewModel;
	}
	protected override void OnAppearing()
	{
		_actorViewModel.OnAppearingCommand.Execute(null);
    }
}