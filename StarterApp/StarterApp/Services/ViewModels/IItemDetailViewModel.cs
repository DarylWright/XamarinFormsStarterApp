using StarterApp.Models;

namespace StarterApp.ViewModels
{
    public interface IItemDetailViewModel
    {
        Item Item { get; set; }
        int Quantity { get; set; }
    }
}