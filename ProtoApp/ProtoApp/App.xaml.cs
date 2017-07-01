using ProtoApp.ViewModels;
using ProtoApp.Views;
using SimpleInjector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProtoApp
{
	public partial class App : Application
	{
	    public App(Container container)
		{
		    RegisterCommonTypes(container);

            container.Verify();

		    InitializeComponent();

			SetMainPage(container);
		}

	    private static void RegisterCommonTypes(Container container)
	    {
	        // Register cross-platform types here

            container.Register<IMainPageFactory, MainPageFactory>(Lifestyle.Scoped);
            container.Register<IItemsViewModel, ItemsViewModel>(Lifestyle.Scoped);
            container.Register<IItemsPageFactory, ItemsPageFactory>(Lifestyle.Scoped);
	        container.Register<IAboutPageFactory, AboutPageFactory>(Lifestyle.Scoped);
	        container.Register<IBonusPageFactory, BonusPageFactory>(Lifestyle.Scoped);
        }

	    private static void SetMainPage(Container container)
		{
            var mainPageFactory = container.GetInstance<IMainPageFactory>();

		    Current.MainPage = mainPageFactory.GetInstance();
		}
	}

    public interface IMainPageFactory
    {
        Page GetInstance();
    }

    public class MainPageFactory : IMainPageFactory
    {
        private readonly IItemsPageFactory _itemsPageFactory;
        private readonly IAboutPageFactory _aboutPageFactory;
        private readonly IBonusPageFactory _bonusPageFactory;

        public MainPageFactory(IItemsPageFactory itemsPageFactory,
                               IAboutPageFactory aboutPageFactory,
                               IBonusPageFactory bonusPageFactory)
        {
            _itemsPageFactory = itemsPageFactory;
            _aboutPageFactory = aboutPageFactory;
            _bonusPageFactory = bonusPageFactory;
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
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(_aboutPageFactory.CreateAboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                    new NavigationPage(_bonusPageFactory.CreateBonusPage())
                    {
                        Title = "Bonus",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    }
                }
            };
        }
    }

    public interface IBonusPageFactory
    {
        BonusPage CreateBonusPage();
    }

    public class BonusPageFactory : IBonusPageFactory
    {
        public BonusPage CreateBonusPage()
        {
            return new BonusPage();
        }
    }

    public interface IAboutPageFactory
    {
        AboutPage CreateAboutPage();
    }

    public class AboutPageFactory : IAboutPageFactory
    {
        public AboutPage CreateAboutPage()
        {
            return new AboutPage();
        }
    }

    public interface IItemsPageFactory
    {
        ItemsPage CreateItemsPage();
    }

    public class ItemsPageFactory : IItemsPageFactory
    {
        private readonly IItemsViewModel _viewModel;

        public ItemsPageFactory(IItemsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public ItemsPage CreateItemsPage()
        {
            return new ItemsPage(_viewModel);
        }
    }
}
