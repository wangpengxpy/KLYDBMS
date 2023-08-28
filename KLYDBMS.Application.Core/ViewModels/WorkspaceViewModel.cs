using KLYDBMS.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;

namespace KLYDBMS.Application.Core.ViewModels
{
    public class WorkspaceViewModel : ViewModelBase, IScreen, IRoutableViewModel
    {
        private readonly IMUserService _mUserService;
        [Reactive]
        public ReactiveCommand<Unit, Unit> Logout { get; set; }

        public string UrlPathSegment => nameof(WorkspaceViewModel);

        public IScreen HostScreen { get; }

        public RoutingState Router { get; } = new RoutingState();

        public ObservableCollection<UserMenuModel> Items { get; } = new();

        public WorkspaceViewModel(IScreen hostScreen) :
          this(hostScreen, Locator.Current.GetService<IMUserService>())
        {

        }

        public WorkspaceViewModel(IScreen screen, IMUserService mUserService)
        {
            HostScreen = screen;

            Logout = ReactiveCommand.Create(() => { HostScreen.Router.NavigateAndReset.Execute(new LoginViewModel(HostScreen)); });

            _mUserService = mUserService;

            RxApp.MainThreadScheduler.Schedule(LoadUserMenus);
        }

        private async void LoadUserMenus()
        {
            var result = await _mUserService.GetUserMenus(KLYMSSession.UserId);

            if (result.Data == null)
            {
                return;
            }

            var models = result.Data;

            foreach (var model in models)
            {
                Items.Add(model);
            }
        }
    }
}
