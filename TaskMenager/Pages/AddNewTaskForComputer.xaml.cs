using TaskMenager.Interfaces;
using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class AddNewTaskForComputer : ContentPage
{
	public AddNewTaskForComputer(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		BindingContext = serviceProvider.GetService<AddNewTaskViewModel>();
	}
}