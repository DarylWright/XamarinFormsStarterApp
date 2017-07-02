using ProtoApp.Models;

namespace ProtoApp.Views
{
    public interface IItemDetailPageFactory
    {
        ItemDetailPage CreateItemDetailPage(Item item);
    }
}