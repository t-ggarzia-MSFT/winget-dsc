// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Services;
using dscui.ViewModels;
using dscui.Views;

namespace dscui.Services;
internal class ValidationPageService : PageService, IValidationPageService
{
    protected override void ConfigurePages()
    {
        Configure<ValidationViewModel, ValidationPage>();
        Configure<ValidationListViewModel, ValidationListPage>();
    }
}
