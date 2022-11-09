using MauiTopicSeven.ViewModels;

namespace MauiTopicSeven.Views;

public partial class PickPhotoPage : ContentPage
{
	public PickPhotoPage()
	{
		InitializeComponent();
        BindingContext = new PickPhotoViewModel();
    }
}