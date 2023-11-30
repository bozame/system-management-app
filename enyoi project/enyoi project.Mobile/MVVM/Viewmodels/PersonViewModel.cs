using enyoi_project.Mobile.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace enyoi_project.Mobile.MVVM.Viewmodels
{
    public class PersonViewModel
    {
        private INavigation _navigation;
        public PersonViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public ICommand NewPersonCommand => new Command(async () => await ExecuteNewPersonCommand());

        private async Task ExecuteNewPersonCommand()
        {
            await _navigation.PushAsync(new CreatePersonView());
        }
    }
}
