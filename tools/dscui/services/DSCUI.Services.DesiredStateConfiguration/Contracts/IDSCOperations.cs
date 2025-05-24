// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Windows.Foundation;

namespace DSCUI.Services.DesiredStateConfiguration.Contracts;

internal interface IDSCOperations
{
    /// <summary>
    /// Apply a DSC configuration set
    /// </summary>
    /// <param name="file">File containing the DSC configuration</param>
    /// <returns>Result of applying the configuration</returns>
    public IAsyncOperationWithProgress<IDSCApplySetResult, IDSCSetChangeData> ApplySetAsync(IDSCFile file);

    /// <summary>
    /// Get details of configuration units in a file
    /// </summary>
    /// <param name="file">File containing the DSC configuration</param>
    /// <returns>Details of configuration units</returns>
    public Task<IDSCSet> GetConfigurationUnitDetailsAsync(IDSCFile file);

    /// <summary>
    /// Validate the configuration in a file
    /// </summary>
    /// <param name="file">File containing the DSC configuration</param>
    public Task ValidateConfigurationAsync(IDSCFile file);
}
