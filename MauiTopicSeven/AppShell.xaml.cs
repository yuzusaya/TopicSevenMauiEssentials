using MauiTopicSeven.Views;

namespace MauiTopicSeven;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
    }
}
