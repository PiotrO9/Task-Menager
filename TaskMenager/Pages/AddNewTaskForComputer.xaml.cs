using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class AddNewTaskForComputer : ContentPage
{
	public AddNewTaskForComputer()
	{
		InitializeComponent();
		BindingContext = new AddNewTaskForComputerViewModel();
	}
}