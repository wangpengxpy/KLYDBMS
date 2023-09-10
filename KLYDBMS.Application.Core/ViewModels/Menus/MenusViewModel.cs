using KLYDBMS.Models;
using ReactiveUI;
using Splat;

namespace KLYDBMS.Application.Core.ViewModels.Menus
{
    public partial class MenusViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(MenusViewModel);


        public MenusViewModel(IScreen screen, UserMenuModel selectedMenu) : this(screen, selectedMenu, Locator.Current.GetService<IMUserService>())
        {

        }

        public MenusViewModel(IScreen screen, UserMenuModel selectedMenu, IMUserService userService)
        {
            HostScreen = screen;
        }
    }
}
