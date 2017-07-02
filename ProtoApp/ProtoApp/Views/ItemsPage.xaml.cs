using System;
using System.Threading.Tasks;
using ProtoApp.Helpers;
using ProtoApp.Models;
using ProtoApp.ViewModels;

using Xamarin.Forms;

namespace ProtoApp.Views
{
	public partial class ItemsPage : ContentPage
    {
        private readonly IItemDetailPageFactory _itemDetailPageFactory;
        private readonly INewItemPageFactory _newItemPageFactory;
        private readonly IItemsViewModel _viewModel;

		public ItemsPage()
		{
			InitializeComponent();
		}

	    public ItemsPage(IItemsViewModel viewModel,
                         IItemDetailPageFactory itemDetailPageFactory,
                         INewItemPageFactory newItemPageFactory) : this()
	    {
	        _itemDetailPageFactory = itemDetailPageFactory;
	        _newItemPageFactory = newItemPageFactory;
	        BindingContext = _viewModel = viewModel;
	    }

	    public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;
            
		    await Navigation.PushAsync(_itemDetailPageFactory.CreateItemDetailPage(item));

            // Manually deselect item
            ItemsListView.SelectedItem = default(object);
		}

	    public async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(_newItemPageFactory.CreateNewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel.Items.Count == 0)
				_viewModel.LoadItemsCommand.Execute(default(object));
		}
	}

    public interface INewItemPageFactory
    {
        Page CreateNewItemPage();
    }

    public class NewItemPageFactory : INewItemPageFactory
    {
        public Page CreateNewItemPage()
        {
            return new NewItemPage();
        }
    }

    public interface IItemDetailPageFactory
    {
        ItemDetailPage CreateItemDetailPage(Item item);
    }

    public class ItemDetailPageFactory : IItemDetailPageFactory
    {
        private readonly IItemDetailViewModel _itemDetailViewModel;

        public ItemDetailPageFactory(IItemDetailViewModel itemDetailViewModel)
        {
            _itemDetailViewModel = itemDetailViewModel;
        }

        public ItemDetailPage CreateItemDetailPage(Item item)
        {
            _itemDetailViewModel.Item = item;

            return new ItemDetailPage(_itemDetailViewModel);
        }
    }
}
