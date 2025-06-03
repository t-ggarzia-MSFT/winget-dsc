﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace dscui.Models;
public class ArrayValue : ConfigurationPropertyValueBase
{
    private ObservableCollection<ConfigurationPropertyValueBase> _value;
    public override object Value
    {
        get => _value;
        set => _value = (ObservableCollection<ConfigurationPropertyValueBase>)value;
    }
    public ArrayValue(ObservableCollection<ConfigurationPropertyValueBase> values) : base(PropertyType.Array)
    {
        _value = values;
    }
}