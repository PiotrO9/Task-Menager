namespace TaskMenager;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		MainPage = new AppShell(serviceProvider);
	}
}
