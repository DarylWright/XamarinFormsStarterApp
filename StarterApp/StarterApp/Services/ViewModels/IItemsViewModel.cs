using StarterApp.Helpers;
using StarterApp.Models;
using Xamarin.Forms;

namespace StarterApp.ViewModels
{
    public interface IItemsViewModel
    {
        ObservableRangeCollection<Item> Items { get; set; }
        Command LoadItemsCommand { get; set; }
    }
}