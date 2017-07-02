using ProtoApp.Models;
using ProtoApp.ViewModels;

namespace ProtoApp.Views
{
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