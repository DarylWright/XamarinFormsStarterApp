using System;
using System.Threading.Tasks;
using StarterApp.Helpers;
using StarterApp.Models;
using StarterApp.ViewModels;
using Xamarin.Forms;

namespace StarterApp.Views
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
}
