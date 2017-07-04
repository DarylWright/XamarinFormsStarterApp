using StarterApp.Models;
using StarterApp.ViewModels;
using Xamarin.Forms;

namespace StarterApp.Views
{
	public partial class ItemDetailPage : ContentPage, IItemDetailPage
	{
	    private readonly IItemDetailViewModel _viewModel;
	    private Item _item;

	    public ItemDetailPage(IItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
		}

	    public Item Item
	    {
	        get => _item;
            set => SetItem(value);
        }

	    private void SetItem(Item value)
	    {
	        _viewModel.Item = _item = value;

	        InitializeComponent();
        }
	}
}
