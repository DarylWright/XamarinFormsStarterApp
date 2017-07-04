using StarterApp.Views;
using Xamarin.Forms;

namespace StarterApp
{
    public class MainPageFactory : IMainPageFactory
    {
        private readonly IItemsPage _itemsPage;
        private readonly AssetCollection _assetCollection;
        private readonly IAboutPage _aboutPage;

        public MainPageFactory(IItemsPage itemsPage,
                               IAboutPage aboutPage,
                               AssetCollection assetCollection)
        {
            _itemsPage = itemsPage;
            _aboutPage = aboutPage;
            _assetCollection = assetCollection;
        }

        public Page GetMainPage()
        {
            return new TabbedPage
            {
                Children =
                {
                    new NavigationPage(_itemsPage as Page)
                    {
                        Title = "Browse",
                        Icon = _assetCollection.FindAsset(AssetIdentifier.TabFeedPng)
                    },
                    new NavigationPage(_aboutPage as Page)
                    {
                        Title = "About",
                        Icon = _assetCollection.FindAsset(AssetIdentifier.TabAboutPng)
                    }
                }
            };
        }
    }
}