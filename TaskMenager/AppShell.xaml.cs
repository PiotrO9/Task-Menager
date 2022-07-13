﻿using TaskMenager.Pages;

namespace TaskMenager;

public partial class AppShell : Shell
{
	public AppShell(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddNewTaskForComputer), typeof(AddNewTaskForComputer));
	}
}
