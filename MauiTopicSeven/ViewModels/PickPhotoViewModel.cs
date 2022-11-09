using MauiTopicSeven.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiTopicSeven.ViewModels
{
    public partial class PickPhotoViewModel
    {
        //void Test()
        //{
        //    PickPhoto();
        //}
    }
    public partial class PickPhotoViewModel : BaseViewModel
    {
        private async Task PickPhoto()
        {
            var service = new PlatformSpecificService();
            var platform = service.GetString();
            await Shell.Current.DisplayAlert("Warning", platform, "OK");
#if ANDROID
            await Shell.Current.DisplayAlert("Warning", "Android only", "OK");
#endif
#if WINDOWS
 await Shell.Current.DisplayAlert("Warning", "Windows only", "OK");
#endif
            var permissionStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (permissionStatus == PermissionStatus.Granted)
            {
                var file = await MediaPicker.PickPhotoAsync();
                if (file != null)
                {
                    var stream = await file.OpenReadAsync();
                    ProfileImage = ImageSource.FromStream(()=>stream);
                }
            }
            else
            {
                permissionStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (permissionStatus != PermissionStatus.Granted)
                {
                    await Shell.Current.DisplayAlert("Warning",
                        "You must grant the permission if you want to use photo", "OK");
                }
            }
        }

        private ImageSource _profileImage;

        public ImageSource ProfileImage
        {
            get=>_profileImage;
            set
            {
                _profileImage = value;
                OnPropertyChanged();
            }
        }
        public ICommand PickPhotoCommand { get; }

        public PickPhotoViewModel()
        {
            PickPhotoCommand = new Command(async()=>
            {
                await PickPhoto();
            });
        }
    }
}
