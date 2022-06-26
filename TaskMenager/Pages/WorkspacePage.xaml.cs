using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class WorkspacePage : ContentPage
{
	public WorkspacePage(WorkspacePageViewModel workspacePageViewModel)
	{
		InitializeComponent();
		BindingContext = workspacePageViewModel;
    }
}