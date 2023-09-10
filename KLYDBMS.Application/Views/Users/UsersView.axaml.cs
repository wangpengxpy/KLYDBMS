using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels.Users;

namespace KLYDBMS.Application.Views.Users
{
    public partial class UsersView : ReactiveUserControl<UsersViewModel>
    {
        public UsersView()
        {
            InitializeComponent();
        }
    }
}
