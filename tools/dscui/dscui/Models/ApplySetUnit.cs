// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using dscui.ViewModels;
using DSCUI.Services.DesiredStateConfiguration.Contracts;

namespace dscui.Models;

public partial class ApplySetUnit : ObservableObject
{
    [ObservableProperty]
    private ApplySetUnitState _state;

    [ObservableProperty]
    private string? _message;

    public DSCConfigurationUnitViewModel Unit { get; }

    public ApplySetUnit(IDSCUnit unit)
    {
        Unit = new (unit);
        State = ApplySetUnitState.NotStarted;
    }
}
