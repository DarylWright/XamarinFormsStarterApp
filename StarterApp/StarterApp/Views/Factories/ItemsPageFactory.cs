using StarterApp.ViewModels;
using StarterApp.Views;
using Xamarin.Forms;

namespace StarterApp
{
    public class ItemsPageFactory : IItemsPageFactory
    {
        private readonly IItemsViewModel _viewModel;
        private readonly IItemDetailPageFactory _itemDetailPageFactory;
        private readonly INewItemPageFactory _newItemPageFactory;

        public ItemsPageFactory(IItemsViewModel viewModel,
            IItemDetailPageFactory itemDetailPageFactory,
            INewItemPageFactory newItemPageFactory)
        {
            _viewModel = viewModel;
            _itemDetailPageFactory = itemDetailPageFactory;
            _newItemPageFactory = newItemPageFactory;
        }

        public Page CreateItemsPage()
        {
            return new ItemsPage(_viewModel, _itemDetailPageFactory, _newItemPageFactory);
        }
    }
}