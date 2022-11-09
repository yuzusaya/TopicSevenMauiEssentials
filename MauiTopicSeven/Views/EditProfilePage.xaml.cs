using MauiTopicSeven.ViewModels;

namespace MauiTopicSeven.Views;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();
        BindingContext = new EditProfileViewModel();
    }
}