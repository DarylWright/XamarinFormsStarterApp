using Xamarin.Forms;

namespace StarterApp
{
    public class MainPageFactory : IMainPageFactory
    {
        private readonly IItemsPageFactory _itemsPageFactory;
        private readonly IAboutPageFactory _aboutPageFactory;
        private readonly AssetCollection _assetCollection;

        public MainPageFactory(IItemsPageFactory itemsPageFactory,
                               IAboutPageFactory aboutPageFactory,
                               AssetCollection assetCollection)
        {
            _itemsPageFactory = itemsPageFactory;
            _aboutPageFactory = aboutPageFactory;
            _assetCollection = assetCollection;
        }

        public Page GetInstance()
        {
            return new TabbedPage
            {
                Children =
                {
                    new NavigationPage(_itemsPageFactory.CreateItemsPage())
                    {
                        Title = "Browse",
                        Icon = _assetCollection.FindAsset(AssetIdentifier.TabFeedPng)
                    },
                    new NavigationPage(_aboutPageFactory.CreateAboutPage())
                    {
                        Title = "About",
                        Icon = _assetCollection.FindAsset(AssetIdentifier.TabAboutPng)
                    }
                }
            };
        }
    }
}