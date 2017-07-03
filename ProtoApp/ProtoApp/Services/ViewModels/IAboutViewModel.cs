using System.Windows.Input;

namespace ProtoApp.ViewModels
{
    public interface IAboutViewModel
    {
        ICommand OpenWebCommand { get; }
    }
}