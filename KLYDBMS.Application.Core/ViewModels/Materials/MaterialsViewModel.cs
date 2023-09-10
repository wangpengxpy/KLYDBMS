using KLYDBMS.Models;
using ReactiveUI;
using Splat;

namespace KLYDBMS.Application.Core.ViewModels.Users
{
    public partial class MaterialsViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(MaterialsViewModel);


        public MaterialsViewModel(IScreen screen, UserMenuModel selectedMenu) : this(screen, selectedMenu, Locator.Current.GetService<IMUserService>())
        {

        }

        public MaterialsViewModel(IScreen screen, UserMenuModel selectedMenu, IMUserService userService)
        {
            HostScreen = screen;
        }
    }
}
