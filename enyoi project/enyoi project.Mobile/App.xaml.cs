using enyoi_project.Mobile.MVVM.Views;

namespace enyoi_project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PersonView());
        }
    }
}