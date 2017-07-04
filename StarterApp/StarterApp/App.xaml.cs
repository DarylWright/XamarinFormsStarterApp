using SimpleInjector;
using StarterApp.Models;
using StarterApp.Services;
using StarterApp.ViewModels;
using StarterApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StarterApp
{
	public partial class App : Application
	{
	    public App(Container container)
		{
            InitializeComponent();

		    RegisterCommonTypes(container);

            container.Verify();

            SetMainPage(container);
		}

	    private static void RegisterCommonTypes(Container container)
	    {
	        // Register cross-platform types here

            container.Register<IMainPageFactory, MainPageFactory>(Lifestyle.Scoped);
            container.Register<IItemsViewModel, ItemsViewModel>(Lifestyle.Scoped);
            container.Register<IItemDetailViewModel, ItemDetailViewModel>(Lifestyle.Scoped);
            container.Register<IAboutViewModel, AboutViewModel>(Lifestyle.Scoped);
            container.Register<IDataStore<Item>, MockDataStore>(Lifestyle.Scoped);
            container.Register<IItemsPage, ItemsPage>(Lifestyle.Scoped);
            container.Register<IAboutPage, AboutPage>(Lifestyle.Scoped);
            container.Register<IItemDetailPage, ItemDetailPage>(Lifestyle.Scoped);
            container.Register<INewItemPage, NewItemPage>(Lifestyle.Scoped);
        }

	    private static void SetMainPage(Container container)
		{
            var mainPageFactory = container.GetInstance<IMainPageFactory>();

		    Current.MainPage = mainPageFactory.GetMainPage();
		}
	}
}
