using StarterApp.ViewModels;
using Xamarin.Forms;

namespace StarterApp.Views
{
	public partial class AboutPage : ContentPage
	{
	    public AboutPage(IAboutViewModel viewModel)
	    {
	        InitializeComponent();

	        BindingContext = viewModel;
	    }
	}
}
