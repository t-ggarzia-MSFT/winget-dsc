using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dscui.Contracts.Services;
using DSCUI.Services.DesiredStateConfiguration.Contracts;

namespace dscui.ViewModels;

public partial class ValidationListViewModel : ObservableRecipient
{
    private readonly IDSC _dsc;
    public readonly IValidationFlowService _flowService;

    [ObservableProperty]
    public partial int CurrentTabIndex { get; set; }

    public ObservableCollection<ValidationViewModel> ValidationViewModels => _flowService.ValidationViewModels;

    public ValidationListViewModel(IDSC dsc, IValidationFlowService flowService)
    {
        _dsc = dsc;
        _flowService = flowService;
    }

    partial void OnCurrentTabIndexChanged(int value)
    {
        _flowService.CurrentTabIndex = value;
    }

    public void CloseTab(ValidationViewModel vm)
    {
        _flowService.RemoveTab(vm);
        if(CurrentTabIndex >= _flowService.ValidationViewModels.Count)
        {
            CurrentTabIndex = _flowService.ValidationViewModels.Count - 1;
        }
    }
    [RelayCommand]
    private async Task OnNewTabAddedAsync()
    {
        _flowService.AddTab();
        CurrentTabIndex = ValidationViewModels.Count - 1;
        await Task.CompletedTask;
    }
}