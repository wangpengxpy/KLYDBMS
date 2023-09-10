using Avalonia.Controls;
using Avalonia.ReactiveUI;
using KLYDBMS.Application.Core.ViewModels;
using KLYDBMS.Models;
using ReactiveUI;

namespace KLYDBMS.Application.Views;

public partial class WorkspaceView : ReactiveUserControl<WorkspaceViewModel>
{
    public WorkspaceView()
    {
        this.WhenActivated(disposable =>
        {
        });

        InitializeComponent();
    }


    private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var menuListBox = sender as ListBox;

        if (menuListBox == null)
        {
            return;
        }

        var selected = menuListBox.SelectedItem;

        ViewModel.SelectedMenu = selected as UserMenuModel;
    }
}
