using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dscui.Contracts.ViewModels;
using DSCUI.Services.DesiredStateConfiguration.Contracts;
using Microsoft.UI.Dispatching;

namespace dscui.ViewModels;

public partial class ValidationListViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDSC _dsc;
    private readonly ValidationViewModelFactory _validationViewModelFactory;

    [ObservableProperty]
    public partial int CurrentValidationViewModel { get; set; }

    public ObservableCollection<ValidationViewModel> ValidationViewModels { get; } = [];

    public void OnNavigatedFrom()
    {

    }

    public void OnNavigatedTo(object parameter)
    {

    }

    public ValidationListViewModel(IDSC dsc)
    {
        _dsc = dsc;
        _validationViewModelFactory = App.GetService<ValidationViewModelFactory>();
         ValidationViewModels.Add(_validationViewModelFactory());
        CurrentValidationViewModel = 0;
    }

    public void CloseTab(ValidationViewModel vm)
    {
        ValidationViewModels.Remove(vm);
    }
    [RelayCommand]
    private async Task OnNewTabAddedAsync()
    {
        ValidationViewModel vm = _validationViewModelFactory();
        ValidationViewModels.Add(vm);

        //TODO fix this
        await Task.Delay(50);
        CurrentValidationViewModel = ValidationViewModels.Count - 1;
        
        await Task.CompletedTask;
    }
}