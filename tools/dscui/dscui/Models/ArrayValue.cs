// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;

namespace dscui.Models;
public class ArrayValue : ConfigurationPropertyValueBase
{
    private List<ConfigurationPropertyValueBase> _value;
    public override object Value
    {
        get => _value;
        set => _value = (List<ConfigurationPropertyValueBase>)value;
    }
    public ArrayValue(List<ConfigurationPropertyValueBase> values) : base(PropertyType.Array)
    {
        _value = values;
    }
}