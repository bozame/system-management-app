using enyoi_project.Mobile.MVVM.Viewmodels;

namespace enyoi_project.Mobile.MVVM.Views;

public partial class CreatePersonView : ContentPage
{
	public CreatePersonView()
	{
		InitializeComponent();
		BindingContext = new CreatePersonViewModel();
	}
}