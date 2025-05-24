// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace dscui.ViewModels.ConfigurationFlow;

public partial class PreviewFileViewModel : ObservableRecipient
{
    public ObservableCollection<object> ConfigurationUnits { get; } = [];
}
