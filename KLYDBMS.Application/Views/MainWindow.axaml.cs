using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels;
using ReactiveUI;

namespace KLYDBMS.Application.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent(true, true);
    }
}