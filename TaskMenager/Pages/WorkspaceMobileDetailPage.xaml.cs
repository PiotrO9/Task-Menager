using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class WorkspaceMobileDetailPage : ContentPage
{
	public WorkspaceMobileDetailPage()
	{
		InitializeComponent();
		BindingContext = new WorkspaceMobileDetailPageViewModel();
	}
}