using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels.Users;

namespace KLYDBMS.Application.Views.Materials
{
    public partial class MaterialsView : ReactiveUserControl<MaterialsViewModel>
    {
        public MaterialsView()
        {
            InitializeComponent();
        }
    }
}
