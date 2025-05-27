// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Services;

namespace dscui.Services;

internal class ConfigurationNavigationService : NavigationService, IConfigurationNavigationService
{
    public ConfigurationNavigationService(IConfigurationPageService pageService)
        : base(pageService)
    {
    }
}
