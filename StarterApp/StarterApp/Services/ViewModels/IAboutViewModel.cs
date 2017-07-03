using System.Windows.Input;

namespace StarterApp.ViewModels
{
    public interface IAboutViewModel
    {
        ICommand OpenWebCommand { get; }
    }
}