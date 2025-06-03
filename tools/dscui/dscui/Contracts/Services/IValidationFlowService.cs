// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using dscui.ViewModels;

namespace dscui.Contracts.Services;
public interface IValidationFlowService
{
    public int CurrentTabIndex { get; set; }

    public void AddTab();

    public void RemoveTab(ValidationViewModel vm);

    public ObservableCollection<ValidationViewModel> ValidationViewModels { get; }
}
