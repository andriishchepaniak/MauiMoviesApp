using MauiMoviesApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiMoviesApp.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public ICommand GoToSearchPageCommand { get; set; }

        public AppShellViewModel()
        {
            GoToSearchPageCommand = new Command(async () => await GoToSearchPage());
        }

        private async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync($"{nameof(SearchPage)}", true);
        }
    }
}
