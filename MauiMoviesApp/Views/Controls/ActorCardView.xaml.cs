using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using System.Windows.Input;

namespace MauiMoviesApp.Views.Controls;

public partial class ActorCardView : ContentView
{
    public static readonly BindableProperty ActorIdProperty = BindableProperty.Create(
           "MovieId",
           typeof(int),
           typeof(ActorCardView),
           0
       );

    public static readonly BindableProperty Profile_PathProperty = BindableProperty.Create(
        "Profile_Path",
        typeof(string),
        typeof(ActorCardView),
        string.Empty
    );

    public static readonly BindableProperty NameProperty = BindableProperty.Create(
        "Name",
        typeof(string),
        typeof(ActorCardView),
        string.Empty
    );

    public static readonly BindableProperty CharacterProperty = BindableProperty.Create(
        "Character",
        typeof(string),
        typeof(ActorCardView),
        string.Empty    
    );

    public int ActorId
    {
        get => (int)GetValue(ActorIdProperty);
        set => SetValue(ActorIdProperty, value);
    }

    public string Profile_Path
    {
        get => (string)GetValue(Profile_PathProperty);
        set => SetValue(Profile_PathProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    
    public string Character
    {
        get => (string)GetValue(CharacterProperty);
        set => SetValue(CharacterProperty, value);
    }

    public ICommand GoToDetailsCommand { get; set; }
    public ActorCardView()
	{
        GoToDetailsCommand = new Command(async () => await GoToDetails());
		InitializeComponent();
	}

    public async Task GoToDetails()
    {
        ActorService actorService = new ActorService();
        var actor = await actorService.GetActorDetails(ActorId);

        var actorMovies = await actorService.GetActorMovies(ActorId);
        await Shell.Current.GoToAsync($"{nameof(ActorDetailsPage)}",
                new Dictionary<string, object> {
                    {"actorId", ActorId },
                    {"actor", actor },
                    {"actorMovies", actorMovies }
                });

        //await Shell.Current.GoToAsync($"{nameof(ActorDetailsPage)}?actorId={ActorId}", true);
    }
}