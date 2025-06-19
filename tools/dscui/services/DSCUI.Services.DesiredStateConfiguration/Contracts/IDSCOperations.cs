// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading.Tasks;
using dscui.Models;
using Microsoft.Management.Configuration;
using Windows.Foundation;

namespace DSCUI.Services.DesiredStateConfiguration.Contracts;

internal interface IDSCOperations
{
    /// <summary>
    /// Open a DSC configuration set from a file
    /// </summary>
    /// <param name="file">Configuration file to open</param>
    /// <returns>Configuration set</returns>
    public Task<IDSCSet> OpenConfigurationSetAsync(IDSCFile file);

    /// <summary>
    /// Apply a DSC configuration set
    /// </summary>
    /// <param name="set">Configuration set to apply</param>
    /// <returns>Result of applying the configuration</returns>
    public IAsyncOperationWithProgress<IDSCApplySetResult, IDSCSetChangeData> ApplySetAsync(IDSCSet set);

    /// <summary>
    /// Get details of configuration units in a set
    /// </summary>
    /// <param name="set">Configuration set to get details for</param>
    public void GetConfigurationUnitDetails(IDSCSet set);

    public Task GetUnit(ConfigurationUnitModel unit);
    public Task SetUnit(ConfigurationUnitModel unit);
    public Task TestUnit(ConfigurationUnitModel unit);
    public Task ExportUnit(ConfigurationUnitModel unit);
}
