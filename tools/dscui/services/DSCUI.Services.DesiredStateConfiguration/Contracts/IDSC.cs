// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading.Tasks;
using dscui.Models;
using Microsoft.Management.Configuration;
using Windows.Foundation;

namespace DSCUI.Services.DesiredStateConfiguration.Contracts;

public interface IDSC
{
    /// <inheritdoc cref="IDSCDeployment.IsUnstubbedAsync" />
    public Task<bool> IsUnstubbedAsync();

    /// <inheritdoc cref="IDSCDeployment.UnstubAsync" />
    public Task<bool> UnstubAsync();

    /// <inheritdoc cref="IDSCOperations.OpenConfigurationSetAsync" />
    public Task<IDSCSet> OpenConfigurationSetAsync(IDSCFile file);

    /// <inheritdoc cref="IDSCOperations.ApplySetAsync" />
    public IAsyncOperationWithProgress<IDSCApplySetResult, IDSCSetChangeData> ApplySetAsync(IDSCSet set);

    /// <inheritdoc cref="IDSCOperations.GetConfigurationUnitDetails" />
    public void GetConfigurationUnitDetails(IDSCSet set);
    /// <inheritdoc cref="IDSCOperations.Get" />
    public Task Get(ConfigurationUnitModel unit);
    public Task Set(ConfigurationUnitModel unit);
    public Task Test(ConfigurationUnitModel unit);
    public Task Export(ConfigurationUnitModel unit);
}
