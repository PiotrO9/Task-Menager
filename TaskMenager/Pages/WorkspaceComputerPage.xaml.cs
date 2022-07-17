using TaskMenager.Models;
using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class WorkspaceComputerPage : ContentPage
{
	private WorkspaceComputerPageViewModel _vm { get; set; }

	public WorkspaceComputerPage(WorkspaceComputerPageViewModel workspaceComputerPageViewModel)
	{
		InitializeComponent();
		BindingContext = _vm = workspaceComputerPageViewModel;
    }

    private void TaskFrameTapped(object sender, EventArgs e)
    {
        Frame FrameClicked = sender as Frame;
        TaskToDo SelectedTask = FrameClicked.BindingContext as TaskToDo;
        _vm.SelectedTask = SelectedTask;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        TaskToDo SelectedTask = checkBox.BindingContext as TaskToDo;
        _vm.UpdateFinishState(SelectedTask);
    }
}