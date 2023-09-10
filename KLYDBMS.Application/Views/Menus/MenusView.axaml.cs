using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels.Menus;

namespace KLYDBMS.Application.Views.Menus
{
    public partial class MenusView : ReactiveUserControl<MenusViewModel>
    {
        public MenusView()
        {
            InitializeComponent();
        }
    }
}
