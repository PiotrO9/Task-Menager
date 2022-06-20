using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
}