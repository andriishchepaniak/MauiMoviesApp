using MauiMoviesApp.Models;
using MauiMoviesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class ActorViewModel : BaseViewModel, IQueryAttributable
    {
        private ActorService _actorService;

        private int id;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private bool isBiographyShow = false;
        public bool IsBiographyShow
        {
            get => isBiographyShow;
            set
            {
                isBiographyShow = value;
                OnPropertyChanged("IsBiographyShow");
            }
        }

        private Actor actor;

        public Actor Actor
        {
            get => actor;
            set
            {
                actor = value;
                OnPropertyChanged("Actor");
            }
        }

        private string showBiographyButtonText = "Show Biography";

        public string ShowBiographyButtonText
        {
            get => showBiographyButtonText;
            set
            {
                if (showBiographyButtonText == value)
                    return;

                showBiographyButtonText = value;
                OnPropertyChanged(nameof(ShowBiographyButtonText));
            }
        }

        public ObservableCollection<Movie> ActorMovies { get; set; } = new();

        public ICommand ShowBiographyCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }
        public ActorViewModel(ActorService actorService)
        {
            _actorService = actorService;
            ShowBiographyCommand = new Command(() => ShowBiography());
            OnAppearingCommand = new Command(async () => await OnAppearing());
        }
        public void ShowBiography()
        {
            IsBiographyShow = !IsBiographyShow;
            ShowBiographyButtonText = IsBiographyShow
                ? "Hide Biography"
                : "Show Biography";
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["actorId"].ToString()));
        }

        public async Task OnAppearing()
        {
            Actor = await _actorService.GetActorDetails(Id);
            var actorMovies = await _actorService.GetActorMovies(Id);

            if (ActorMovies.Count != 0)
                ActorMovies.Clear();

            foreach (var movie in actorMovies)
            {
                ActorMovies.Add(movie);
            }
        }
    }
}
