using ProtoApp.Helpers;
using ProtoApp.Models;
using Xamarin.Forms;

namespace ProtoApp.ViewModels
{
    public interface IItemsViewModel
    {
        ObservableRangeCollection<Item> Items { get; set; }
        Command LoadItemsCommand { get; set; }
    }
}