using ProtoApp.Views;
using Xamarin.Forms;

namespace ProtoApp
{
    public class BonusPageFactory : IBonusPageFactory
    {
        public Page CreateBonusPage()
        {
            return new BonusPage();
        }
    }
}