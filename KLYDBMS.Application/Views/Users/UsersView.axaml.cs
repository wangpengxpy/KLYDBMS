using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels.Users;
using KLYDBMS.Models;
using ReactiveUI;

namespace KLYDBMS.Application.Views.Users
{
    public partial class UsersView : ReactiveUserControl<UsersViewModel>
    {
        public UsersView()
        {
            this.WhenActivated(disposable =>
            {
            });

            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            if (dataGrid == null)
            {
                return;
            }
            dataGrid.RowBackground = (IBrush)new BrushConverter().ConvertFrom("#FD5E1D");
        }
    }
}
