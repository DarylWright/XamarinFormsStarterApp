using ProtoApp.Views;
using Xamarin.Forms;

namespace ProtoApp
{
    public class AboutPageFactory : IAboutPageFactory
    {
        public Page CreateAboutPage()
        {
            return new AboutPage();
        }
    }
}