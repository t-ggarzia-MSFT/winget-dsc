// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using dscui.Contracts.Services;
using dscui.ViewModels;

namespace dscui.Services;
public partial class ValidationFlowService : IValidationFlowService
{
    private readonly ValidationViewModelFactory _validationViewModelFactory;

    public int CurrentTabIndex { get; set; }

    public ObservableCollection<ValidationViewModel> ValidationViewModels { get; } = [];

    public ValidationFlowService()
    {
        _validationViewModelFactory = App.GetService<ValidationViewModelFactory>();
    }
    public void AddTab()
    {
        ValidationViewModel vm = _validationViewModelFactory();
        ValidationViewModels.Add(vm);
    }

    public void RemoveTab(ValidationViewModel vm)
    {
        if (vm == null)
        {
            return;
        }

        ValidationViewModels.Remove(vm);
    }
}
