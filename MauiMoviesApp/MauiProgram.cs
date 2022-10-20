using MauiMoviesApp.Services;
using MauiMoviesApp.ViewModels;
using MauiMoviesApp.Views;
using MauiMoviesApp.Views.Controls;

namespace MauiMoviesApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddScoped<MovieService>();
		builder.Services.AddScoped<GenreService>();
		builder.Services.AddScoped<ActorService>();

		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<AppShellViewModel>();
		builder.Services.AddTransient<MoviesViewModel>();
		builder.Services.AddTransient<MovieDetailsViewModel>();
		builder.Services.AddTransient<ActorViewModel>();
		builder.Services.AddTransient<SearchViewModel>();

		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddTransient<MoviesPage>();
		builder.Services.AddTransient<MovieDetailsPage>();
		builder.Services.AddTransient<ActorDetailsPage>();
		builder.Services.AddTransient<SearchPage>();

		return builder.Build();
	}
}
