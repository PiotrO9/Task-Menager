using Microsoft.Extensions.DependencyInjection;
using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class AddNewTaskForMobile : ContentPage
{
    public AddNewTaskForMobile(IServiceProvider serviceProvider)
    {
		InitializeComponent();
        BindingContext = serviceProvider.GetService<AddNewTaskViewModel>();
    }
}