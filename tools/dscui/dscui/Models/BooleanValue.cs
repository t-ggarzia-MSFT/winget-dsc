// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dscui.Models;
public class BooleanValue : ConfigurationPropertyValueBase
{
    private bool _value;

    public override object Value
    {
        get => _value;
        set => _value = (bool)value;
    }
    public BooleanValue(bool value) : base(PropertyType.Boolean)
    {
        _value = value;
    }
}
