using MauiTopicSeven.ViewModels;

namespace MauiTopicSeven;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }
}

