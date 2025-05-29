// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dscui.Models;
public class ObjectValue : ConfigurationPropertyValueBase
{
    public override object Value
    {
        get => this.Value;
        set => this.Value = (List<ConfigurationProperty>)value;
    }
    public ObjectValue(List<ConfigurationProperty> value) : base(PropertyType.Object)
    {
        this.Value = value;
    }   
}
