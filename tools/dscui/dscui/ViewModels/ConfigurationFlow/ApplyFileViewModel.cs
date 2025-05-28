// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dscui.Contracts.Services;

namespace dscui.ViewModels.ConfigurationFlow;

public partial class ApplyFileViewModel : ObservableRecipient
{
    private readonly IConfigurationNavigationService _navigationService;

    public ApplyFileViewModel(IConfigurationNavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task OnDoneAsync()
    {
        _navigationService.NavigateToDefaultPage();
        await Task.CompletedTask;
    }
}
