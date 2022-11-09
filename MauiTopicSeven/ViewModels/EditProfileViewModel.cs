using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiTopicSeven.ViewModels
{
    public class EditProfileViewModel
    {
        public string Name { get; set; }
        public ICommand SaveCommand { get; }

        public EditProfileViewModel()
        {
            SaveCommand = new Command(async () =>
            {
                MessagingCenter.Send(this, "ProfileChanged",Name);
                await Shell.Current.GoToAsync("..");
            });
        }
    }
}
