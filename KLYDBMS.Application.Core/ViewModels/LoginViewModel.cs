using KLYDBMS.Models;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System.Reactive;
using System.Reactive.Linq;

namespace KLYDBMS.Application.Core.ViewModels
{
    public partial class LoginViewModel : ViewModelBase, IRoutableViewModel
    {
        private IMUserService _userService;
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = nameof(LoginViewModel);
        public ReactiveCommand<Unit, Unit> Login { get; }
        public ReactiveCommand<Unit, Unit> Exit { get; }

        [Reactive]
        public string UserName { get; set; }
        [Reactive]
        public string Password { get; set; }
        [Reactive]
        public string LoginFailedMsg { get; set; }

        public LoginViewModel(IScreen screen) : this(screen, Locator.Current.GetService<IMUserService>())
        {
            
        }

        public LoginViewModel(IScreen screen, IMUserService userService)
        {
            HostScreen = screen;

            _userService = userService;

            var canLogin = this.WhenAnyValue(vm => vm.UserName, vm => vm.Password,
                (userName, password) =>
                    !string.IsNullOrEmpty(userName) &&
                    !string.IsNullOrEmpty(password));

            Login = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);

            Exit = ReactiveCommand.Create(ExitApplication);
        }

        private async Task LoginAsync()
        {
            var result = _userService.Login(new UserModel()
            {
                UserName = UserName,
                Password = Password
            });

            if (!result.Succeeded)
            {
                LoginFailedMsg = result.Message;
            }
            else
            {
                LoginFailedMsg = null;

                KLYMSSession.UserId = result.Data;
                KLYMSSession.UserName = UserName;

                await HostScreen.Router.NavigateAndReset.Execute(new WorkspaceViewModel(HostScreen));
            }
        }

        private void ExitApplication()
        {
            Locator.Current.GetService<IApplication>().Shutdown();
        }
    }
}
