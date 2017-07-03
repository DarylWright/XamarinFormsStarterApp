using Xamarin.Forms;

namespace StarterApp.Views
{
    public class NewItemPageFactory : INewItemPageFactory
    {
        public Page CreateNewItemPage()
        {
            return new NewItemPage();
        }
    }
}