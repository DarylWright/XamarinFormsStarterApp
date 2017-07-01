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

            container.Register<IMainPageFactory, MainPageFactory>();
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
        public Page GetInstance()
        {
            return new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                    new NavigationPage(new BonusPage())
                    {
                        Title = "Bonus",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    }
                }
            };
        }
    }
}
