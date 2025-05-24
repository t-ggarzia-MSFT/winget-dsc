// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading.Tasks;
using DSCUI.Services.DesiredStateConfiguration.Contracts;
using Windows.Foundation;

namespace DSCUI.Services.DesiredStateConfiguration.Services;

internal sealed class DSC : IDSC
{
    private readonly IDSCDeployment _dscDeployment;
    private readonly IDSCOperations _dscOperations;

    public DSC(IDSCDeployment dscDeployment, IDSCOperations dscOperations)
    {
        _dscDeployment = dscDeployment;
        _dscOperations = dscOperations;
    }

    /// <inheritdoc/>
    public async Task<bool> IsUnstubbedAsync() => await _dscDeployment.IsUnstubbedAsync();

    /// <inheritdoc/>
    public async Task<bool> UnstubAsync() => await _dscDeployment.UnstubAsync();

    /// <inheritdoc/>
    public IAsyncOperationWithProgress<IDSCApplySetResult, IDSCSetChangeData> ApplySetAsync(IDSCFile file) => _dscOperations.ApplySetAsync(file);

    /// <inheritdoc/>
    public async Task<IDSCSet> GetConfigurationUnitDetailsAsync(IDSCFile file) => await _dscOperations.GetConfigurationUnitDetailsAsync(file);

    /// <inheritdoc/>
    public async Task ValidateConfigurationAsync(IDSCFile file) => await _dscOperations.ValidateConfigurationAsync(file);
}
