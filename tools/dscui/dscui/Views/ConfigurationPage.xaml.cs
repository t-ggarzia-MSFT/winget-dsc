using dscui.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace dscui.Views;

public sealed partial class ConfigurationPage : Page
{
    public ConfigurationViewModel ViewModel
    {
        get;
    }

    public ConfigurationPage()
    {
        ViewModel = App.GetService<ConfigurationViewModel>();
        InitializeComponent();
    }
}
