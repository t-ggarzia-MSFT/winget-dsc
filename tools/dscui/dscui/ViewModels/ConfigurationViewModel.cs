using CommunityToolkit.Mvvm.ComponentModel;
using dscui.Contracts.ViewModels;
using DSCUI.Services.DesiredStateConfiguration.Contracts;
using Windows.Storage;

namespace dscui.ViewModels;

public partial class ConfigurationViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDSC _dsc;

    public ConfigurationViewModel(IDSC dsc)
    {
        _dsc = dsc;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is IStorageFile file)
        {
            // var dscFile = await DSCFile.LoadAsync(file.Path);
        }
    }

    public void OnNavigatedFrom()
    {
        // No-op
    }
}
