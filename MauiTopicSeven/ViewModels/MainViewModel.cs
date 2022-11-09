using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiTopicSeven.Views;

namespace MauiTopicSeven.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _name = "Anonymous";

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public ICommand GoToEditProfilePageCommand { get; }

        public MainViewModel()
        {
            GoToEditProfilePageCommand = new Command(() =>
            {
                Shell.Current.GoToAsync($"{nameof(EditProfilePage)}");
            });
            MessagingCenter.Subscribe<EditProfileViewModel,string>(this,"ProfileChanged", (sender, name) =>
            {
                Name = name;
            });
        }
    }
}
