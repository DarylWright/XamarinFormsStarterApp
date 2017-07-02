
using ProtoApp.ViewModels;

using Xamarin.Forms;

namespace ProtoApp.Views
{
	public partial class ItemDetailPage : ContentPage
	{
	    private readonly IItemDetailViewModel _viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(IItemDetailViewModel viewModel) : this()
		{
			BindingContext = _viewModel = viewModel;
		}
	}
}
