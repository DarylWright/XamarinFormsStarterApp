
using ProtoApp.ViewModels;
using Xamarin.Forms;

namespace ProtoApp.Views
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
