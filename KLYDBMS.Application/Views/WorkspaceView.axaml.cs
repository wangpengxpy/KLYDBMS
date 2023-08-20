using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels;
using ReactiveUI;

namespace KLYDBMS.Application.Views;

public partial class WorkspaceView : ReactiveUserControl<WorkspaceViewModel>
{
    public WorkspaceView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}
