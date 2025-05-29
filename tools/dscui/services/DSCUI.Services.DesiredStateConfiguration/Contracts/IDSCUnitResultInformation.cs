// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using Microsoft.Management.Configuration;

namespace DSCUI.Services.DesiredStateConfiguration.Contracts;

public interface IDSCUnitResultInformation
{
    /// <summary>
    /// Gets the error code of the result.
    /// </summary>
    public Exception ResultCode{ get; }

    /// <summary>
    /// Gets the short description of the failure.
    /// </summary>
    public string Description{ get; }

    /// <summary>
    /// Gets a more detailed error message appropriate for diagnosing the root cause of an error.
    /// </summary>
    public string Details{ get; }

    /// <summary>
    /// Gets the source of the result.
    /// </summary>
    ConfigurationUnitResultSource ResultSource { get; }
}
