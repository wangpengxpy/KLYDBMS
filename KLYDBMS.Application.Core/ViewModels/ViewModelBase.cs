using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;

namespace KLYDBMS.Application.Core.ViewModels;

public class ViewModelBase : ReactiveObject, IActivatableViewModel, IValidatableViewModel
{
    public ViewModelActivator Activator { get; } = new ViewModelActivator();

    public ValidationContext ValidationContext { get; } = new();
}
