using ProtoApp.ViewModels;
using ProtoApp.Views;
using Xamarin.Forms;

namespace ProtoApp
{
    public class AboutPageFactory : IAboutPageFactory
    {
        private readonly IAboutViewModel _viewModel;

        public AboutPageFactory(IAboutViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public Page CreateAboutPage()
        {
            return new AboutPage(_viewModel);
        }
    }
}