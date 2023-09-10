using KLYDBMS.Models;
using ReactiveUI;
using Splat;

namespace KLYDBMS.Application.Core.ViewModels.Roles
{
    public partial class RolesViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(RolesViewModel);


        public RolesViewModel(IScreen screen, UserMenuModel selectedMenu) : this(screen, selectedMenu, Locator.Current.GetService<IMUserService>())
        {

        }

        public RolesViewModel(IScreen screen, UserMenuModel selectedMenu, IMUserService userService)
        {
            HostScreen = screen;
        }
    }
}
