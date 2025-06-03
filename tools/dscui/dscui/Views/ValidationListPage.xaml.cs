using System;
using dscui.Contracts.Views;
using dscui.Helpers;
using dscui.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Devices.Core;

namespace dscui.Views;
public sealed partial class ValidationListPage : Page, IView<ValidationListViewModel>
{
    public ValidationListViewModel ViewModel
    {
        get;
    }

    public ValidationListPage()
    {
        ViewModel = App.GetService<ValidationListViewModel>();
        InitializeComponent();
    }

    private void CloseValidationTab(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        if (args.Item is TabViewItem t)
        {
            sender.TabItems.Remove(t);
        }
    }
}