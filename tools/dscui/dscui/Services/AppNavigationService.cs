// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Services;
using Microsoft.UI.Xaml.Controls;

namespace dscui.Services;

internal class AppNavigationService : NavigationService, IAppNavigationService
{
    public AppNavigationService(IAppPageService pageService)
        : base(pageService)
    {
    }

    protected override Frame? GetDefaultFrame()
    {
        return App.MainWindow.Content as Frame;
    }
}
