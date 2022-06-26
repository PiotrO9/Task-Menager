using TaskMenager.ViewModels;

namespace TaskMenager.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        BindingContext = loginPageViewModel;
    }
}