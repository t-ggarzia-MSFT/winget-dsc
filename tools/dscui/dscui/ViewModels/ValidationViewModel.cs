using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dscui.Contracts.ViewModels;
using dscui.Models;
using DSCUI.Services.DesiredStateConfiguration.Contracts;

namespace dscui.ViewModels;

public delegate ValidationViewModel ValidationViewModelFactory();

public partial class ValidationViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDSC _dsc;

    [ObservableProperty]
    public partial string ModuleName { get; set; } = "";

    [ObservableProperty]
    public partial bool IsV3 { get; set; } = false;

    [ObservableProperty]
    public partial bool ShowRawData { get; set; } = false;

    [ObservableProperty]
    public partial string RawData { get; set; } = "";

    public ObservableCollection<ConfigurationProperty> Properties { get; } = new();

    public ValidationViewModel(IDSC dsc)
    {
        _dsc = dsc;
    }

    public async void OnNavigatedTo(object parameter)
    {
        // No-op
    }

    public void OnNavigatedFrom()
    {
        // No-op
    }

    [RelayCommand]
    private async Task OnGetAsync()
    {
        System.Diagnostics.Debug.WriteLine("Get");
    }
    [RelayCommand]
    private async Task OnSetAsync()
    {
        System.Diagnostics.Debug.WriteLine("Set");
    }
    [RelayCommand]
    private async Task OnTestAsync()
    {
        System.Diagnostics.Debug.WriteLine("Test");
    }
    [RelayCommand]
    private async Task OnExportAsync()
    {
        System.Diagnostics.Debug.WriteLine("Export");
    }
}
