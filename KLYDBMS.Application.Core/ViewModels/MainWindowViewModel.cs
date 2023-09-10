using ReactiveUI;

namespace KLYDBMS.Application.Core.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new RoutingState();

    public MainWindowViewModel()
    {
        var loginViewModel = new LoginViewModel(this);

        Router.Navigate.Execute(loginViewModel);
    }
}
