using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels;

namespace KLYDBMS.Application.Views
{
    public partial class LoginView : ReactiveUserControl<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent(true);
        }
    }
}
