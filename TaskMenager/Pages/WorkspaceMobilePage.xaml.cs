using TaskMenager.Interfaces;
using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class WorkspaceMobilePage : ContentPage
{
    private WorkspaceMobilePageViewModel _vm { get; set; }
    public WorkspaceMobilePage(WorkspaceMobilePageViewModel workspaceMobilePageViewModel)
	{
		InitializeComponent();
        BindingContext = _vm = workspaceMobilePageViewModel;
    }

    private void TaskTapped(object sender, EventArgs e)
    {

    }
}