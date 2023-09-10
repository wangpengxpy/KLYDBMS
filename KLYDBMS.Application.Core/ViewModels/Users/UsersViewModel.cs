using KLYDBMS.Models;
using ReactiveUI;
using Splat;

namespace KLYDBMS.Application.Core.ViewModels.Users
{
    public partial class UsersViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(UsersViewModel);


        public UsersViewModel(IScreen screen, UserMenuModel selectedMenu) : this(screen, selectedMenu, Locator.Current.GetService<IMUserService>())
        {

        }

        public UsersViewModel(IScreen screen, UserMenuModel selectedMenu, IMUserService userService)
        {
            HostScreen = screen;
        }
    }
}
