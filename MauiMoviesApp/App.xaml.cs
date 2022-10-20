using MauiMoviesApp.ViewModels;

namespace MauiMoviesApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
		AppShellViewModel appShellViewModel = new AppShellViewModel();

		MainPage = new AppShell(appShellViewModel);
	}
}
