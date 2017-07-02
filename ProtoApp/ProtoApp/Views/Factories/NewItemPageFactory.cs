using Xamarin.Forms;

namespace ProtoApp.Views
{
    public class NewItemPageFactory : INewItemPageFactory
    {
        public Page CreateNewItemPage()
        {
            return new NewItemPage();
        }
    }
}