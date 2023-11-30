using enyoi_project.Mobile.MVVM.Viewmodels;

namespace enyoi_project.Mobile.MVVM.Views;

public partial class PersonView : ContentPage
{
	public PersonView()
	{
		InitializeComponent();
		BindingContext = new PersonViewModel(this.Navigation);
	}
}