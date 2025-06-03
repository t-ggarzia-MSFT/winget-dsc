// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Services;
using dscui.ViewModels;

namespace dscui.Services;
internal class ValidationNavigationService : NavigationService, IValidationNavigationService
{
    public ValidationNavigationService(IValidationPageService pageService)
        : base(pageService)
    {
    }

    public bool NavigateToDefaultPage(object? parameter = null, bool clearNavigation = false)
    {
        return NavigateTo<ValidationListViewModel>(parameter, clearNavigation);
    }
}
