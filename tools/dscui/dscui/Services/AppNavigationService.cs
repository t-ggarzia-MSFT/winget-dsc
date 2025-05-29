// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Services;
using dscui.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace dscui.Services;

internal class AppNavigationService : NavigationService, IAppNavigationService
{
    public AppNavigationService(IAppPageService pageService)
        : base(pageService)
    {
    }

    public bool NavigateToDefaultPage(object? parameter = null, bool clearNavigation = false)
    {
        return NavigateTo<MainViewModel>(parameter, clearNavigation);
    }

    protected override Frame? GetDefaultFrame()
    {
        return App.MainWindow.Content as Frame;
    }
}
