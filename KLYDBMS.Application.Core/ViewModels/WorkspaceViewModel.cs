using KLYDBMS.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

namespace KLYDBMS.Application.Core.ViewModels
{
    public class WorkspaceViewModel : ViewModelBase, IScreen, IRoutableViewModel
    {
        [Reactive] 
        public ReactiveCommand<Unit, Unit> Logout { get; set; }
        public string UrlPathSegment => nameof(WorkspaceViewModel);

        public IScreen HostScreen { get; }

        public RoutingState Router { get; } = new RoutingState();

        public WorkspaceViewModel(IScreen screen)
        {
            HostScreen = screen;

            Logout = ReactiveCommand.Create(() => { HostScreen.Router.NavigateAndReset.Execute(new LoginViewModel(HostScreen)); });
        }

        public List<Menu> Menus { get; set; } = new List<Menu>
        {
            new Menu(){
                Id = 1, Name = "资料管理",
                Children = new List<Menu>()
                {
                    new Menu(){ Id = 1, Name = "View as slide show"},
                    new Menu(){ Id = 2, Name = "View as slide show"},
                    new Menu(){ Id = 3, Name = "View as slide show"},
                    new Menu(){ Id = 4, Name = "View as slide show"}
                }
            },
            new Menu(){
                Id = 2, Name = "用户管理",
                Children = new List<Menu>()
                {
                    new Menu(){ Id = 5, Name = "Order prints online5"},
                    new Menu(){ Id = 6, Name = "Order prints online6"},
                    new Menu(){ Id = 7, Name = "Order prints online7"},
                    new Menu(){ Id = 8, Name = "Order prints online8"}
                }
            },
            new Menu(){
                Id = 3, Name = "菜单管理",
                Children = new List<Menu>()
                {
                    new Menu(){ Id = 9, Name = "Copy all item to CD9"},
                    new Menu(){ Id = 10, Name = "Copy all item to CD10"},
                    new Menu(){ Id = 11, Name = "Copy all item to CD11"},
                    new Menu(){ Id = 12, Name = "Copy all item to CD12"}
                }
            }
        };
    }
}
