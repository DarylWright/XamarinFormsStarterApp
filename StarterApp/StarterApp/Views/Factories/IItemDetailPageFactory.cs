using StarterApp.Models;

namespace StarterApp.Views
{
    public interface IItemDetailPageFactory
    {
        ItemDetailPage CreateItemDetailPage(Item item);
    }
}