using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class WorkspaceComputerPage : ContentPage
{
	public WorkspaceComputerPage(WorkspaceComputerPageViewModel workspaceComputerPageViewModel)
	{
		InitializeComponent();
		BindingContext = workspaceComputerPageViewModel;
    }

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{

	}
}