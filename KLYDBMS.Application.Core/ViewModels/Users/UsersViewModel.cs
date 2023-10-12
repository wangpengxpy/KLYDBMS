using DynamicData;
using KLYDBMS.Models;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace KLYDBMS.Application.Core.ViewModels.Users
{
    public partial class UsersViewModel : ViewModelBase, IRoutableViewModel
    {
        private readonly IMUserService _mUserService;

        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(UsersViewModel);

        public ObservableCollection<UserListModel> Items { get; } = new();

        public UsersViewModel(IScreen screen, UserMenuModel selectedMenu) :
            this(screen, selectedMenu, Locator.Current.GetService<IMUserService>())
        {

        }

        public UsersViewModel(IScreen screen, UserMenuModel selectedMenu, IMUserService mUserService)
        {
            HostScreen = screen;

            _mUserService = mUserService;

            RxApp.MainThreadScheduler.Schedule(LoadUsers);
        }


        private async void LoadUsers()
        {
            var users = await _mUserService.GetUserList();

            Items.AddRange(users);
        }
    }
}
