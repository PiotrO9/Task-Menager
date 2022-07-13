using TaskMenager.Engines;
using TaskMenager.Interfaces;
using TaskMenager.Pages;
using TaskMenager.ViewModels;

namespace TaskMenager;

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

		builder.Services.AddSingleton<IRealmEngine, RealmEngine>();
		builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();

		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<WorkspacePageViewModel>();
		builder.Services.AddSingleton<WorkspaceComputerPageViewModel>();
		builder.Services.AddTransient<AddNewTaskForComputerViewModel>();

		builder.Services.AddSingleton<WorkspacePage>();
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<WorkspaceComputerPage>();
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddTransient<AddNewTaskForComputer>();

        return builder.Build();
	}
}
