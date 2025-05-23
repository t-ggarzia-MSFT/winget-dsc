// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using dscui.Contracts.Views;
using dscui.ViewModels.ConfigurationFlow;
using Microsoft.UI.Xaml.Controls;

namespace dscui.Views.ConfigurationFlow;

public sealed partial class SelectFilePage : Page, IView<SelectFileViewModel>
{
    public SelectFileViewModel ViewModel { get; }

    public SelectFilePage()
    {
        ViewModel = App.GetService<SelectFileViewModel>();
        this.InitializeComponent();
    }
}
