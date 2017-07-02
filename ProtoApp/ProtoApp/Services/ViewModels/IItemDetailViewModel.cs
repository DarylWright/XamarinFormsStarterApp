using ProtoApp.Models;

namespace ProtoApp.ViewModels
{
    public interface IItemDetailViewModel
    {
        Item Item { get; set; }
        int Quantity { get; set; }
    }
}