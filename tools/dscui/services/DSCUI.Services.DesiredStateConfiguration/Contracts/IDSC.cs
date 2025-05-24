// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace DSCUI.Services.DesiredStateConfiguration.Contracts;

public interface IDSC
{
    /// <inheritdoc cref="IDSCDeployment.IsUnstubbedAsync" />
    public Task<bool> IsUnstubbedAsync();

    /// <inheritdoc cref="IDSCDeployment.UnstubAsync" />
    public Task<bool> UnstubAsync();

    /// <inheritdoc cref="IDSCOperations.ApplyConfigurationAsync" />
    public Task<IDSCApplySetResult> ApplyConfigurationAsync(IDSCFile file);

    /// <inheritdoc cref="IDSCOperations.GetConfigurationUnitDetailsAsync" />
    public Task<IDSCSet> GetConfigurationUnitDetailsAsync(IDSCFile file);

    /// <inheritdoc cref="IDSCOperations.ValidateConfigurationAsync" />
    public Task ValidateConfigurationAsync(IDSCFile file);
}
