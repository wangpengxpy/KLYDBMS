using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace KLYDBMS.Application.Core.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    [Reactive]
    public bool Loading { get; set; } = true;
    public RoutingState Router { get; } = new RoutingState();

    public MainWindowViewModel()
    {
        var loginViewModel = new LoginViewModel(this);

        Router.Navigate.Execute(loginViewModel);

        Loading = false;
    }
}
