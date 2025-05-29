using System.Security.Cryptography.Pkcs;
using CommunityToolkit.Mvvm.ComponentModel;

namespace dscui.Models;

public partial class ConfigurationProperty(string name, ConfigurationPropertyValueBase value) : ObservableObject
{
    [ObservableProperty]
    public partial string Name { get; set; } = name;

    [ObservableProperty]
    public partial ConfigurationPropertyValueBase Value { get; set; } = value;
}
