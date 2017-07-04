using Android.App;
using Android.Content.PM;
using Android.OS;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace StarterApp.Droid
{
    [Activity(Label = "StarterApp.Android", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterTypes(container);

            using (AsyncScopedLifestyle.BeginScope(container))
            {
                LoadApplication(new App(container));
            }
        }

        private static void RegisterTypes(Container container)
        {
            // Register platform-specific types here
            container.Register<AssetCollection, AndroidAssetCollection>(Lifestyle.Scoped);
        }
    }
}