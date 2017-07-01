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
	    private readonly IItemsViewModel _viewModel;

		public ItemsPage()
		{
			InitializeComponent();
		}

	    public ItemsPage(IItemsViewModel viewModel) : this()
	    {
	        BindingContext = _viewModel = viewModel;
	    }

	    public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

	    public async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel.Items.Count == 0)
				_viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
