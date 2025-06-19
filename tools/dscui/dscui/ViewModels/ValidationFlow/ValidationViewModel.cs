using System.Collections.ObjectModel;
using System.Management.Automation.Language;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dscui.Contracts.Services;
using dscui.Contracts.ViewModels;
using dscui.Models;
using dscui.Services;
using DSCUI.Services.DesiredStateConfiguration.Contracts;
using DSCUI.Services.DesiredStateConfiguration.Models;
using Microsoft.Management.Configuration;
using Microsoft.UI.Xaml;
using Newtonsoft.Json.Linq;
using Windows.Foundation.Collections;

namespace dscui.ViewModels;

public delegate ValidationViewModel ValidationViewModelFactory();

public partial class ValidationViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDSC _dsc;
    private readonly IValidationFlowService _validationFlowService;

    [ObservableProperty]
    public partial string ModuleName { get; set; } = "";

    [ObservableProperty]
    public partial bool IsV3 { get; set; } = false;

    [ObservableProperty]
    public partial bool ShowRawData { get; set; } = false;

    [ObservableProperty]
    public partial string RawData { get; set; } = "";

    [ObservableProperty]
    public partial string TabHeader { get; set; } = "New Tab";

    [ObservableProperty]
    public partial bool ActionsEnabled { get; set; } = true;

    public ObservableCollection<ConfigurationProperty> Properties { get; } = new();

    public ValidationViewModel(IDSC dsc)
    {
        _dsc = dsc;
        _validationFlowService = App.GetService<IValidationFlowService>();
    }

    public async void OnNavigatedTo(object parameter)
    {
        // No-op
        await Task.CompletedTask;
    }

    public void OnNavigatedFrom()
    {
        // No-op
    }
    private ConfigurationUnitModel CreateConfigurationUnitModel()
    {
        ConfigurationUnitModel unit = new();
        unit.Type = ModuleName;
        //foreach (ConfigurationProperty p in Properties)
        //{
        //    unit.Settings.Add(new(p.Name, p.Value.Value));
        //}
        CreateConfigurationUnitModelHelper(unit.Settings, Properties);
        return unit;
    }
    private void CreateConfigurationUnitModelHelper(ValueSet settings, ObservableCollection<ConfigurationProperty> properties)
    {
        foreach (var property in properties)
        {
            if (property.Value.Value is string s)
            {
                settings.Add(new(property.Name, s));
            }
            else if (property.Value.Value is bool b)
            {
                settings.Add(new(property.Name, b));
            }
            else if (property.Value.Value is double d)
            {
                settings.Add(new(property.Name, d));
            }
            else if (property.Value.Value is ObservableCollection<ConfigurationProperty> nestedProperties)
            {
                ValueSet nestedSettings = new();
                CreateConfigurationUnitModelHelper(nestedSettings, nestedProperties);
                settings.Add(new(property.Name, nestedSettings));
            }
        }
    }
    partial void OnModuleNameChanged(string oldValue, string newValue)
    {
        TabHeader = newValue;
    }
    [RelayCommand]
    private async Task OnConvertYamlToUIAsync()
    {
        var unit = CreateConfigurationUnitModel();
        unit.FromYaml(RawData);
        ModuleName = unit.Type;

        Properties.Clear();

        ConvertYamlToUIHelper(Properties, unit.Settings);
    }
    private void ConvertYamlToUIHelper(ObservableCollection<ConfigurationProperty> properties, ValueSet settings)
    {
        foreach (var kvp in settings)
        {
            if (kvp.Value is string s)
            {
                properties.Add(new(kvp.Key, new StringValue(s)));
            }
            else if (kvp.Value is bool b)
            {
                properties.Add(new(kvp.Key, new BooleanValue(b)));
            }
            else if (kvp.Value is double d)
            {
                properties.Add(new(kvp.Key, new NumberValue(d)));
            }else if (kvp.Value is ValueSet v)
            {
                ObservableCollection<ConfigurationProperty> nestedProperties = new();
                ConvertYamlToUIHelper(nestedProperties, v);
                properties.Add(new(kvp.Key, new ObjectValue(nestedProperties)));
            }
        }
    }
    [RelayCommand]
    private async Task OnConvertUIToYamlAsync()
    {
        RawData = CreateConfigurationUnitModel().ToYaml();
    }

    [RelayCommand]
    private async Task OnGetAsync()
    {
        ActionsEnabled = false;
        ConfigurationUnitModel unit = CreateConfigurationUnitModel();
        await _dsc.Get(unit);

        ValidationViewModel vm = _validationFlowService.ValidationViewModels[^1];
        RawData = unit.ToYaml();
        ActionsEnabled = true;
    }
    [RelayCommand]
    private async Task OnSetAsync()
    {
        ActionsEnabled = false;
        ConfigurationUnitModel unit = CreateConfigurationUnitModel();
        await _dsc.Set(unit);
        ActionsEnabled = true;
    }
    [RelayCommand]
    private async Task OnTestAsync()
    {
        ActionsEnabled = false;
        ConfigurationUnitModel unit = CreateConfigurationUnitModel();
        await _dsc.Test(unit);
        ActionsEnabled = true;
    }
    [RelayCommand]
    private async Task OnExportAsync()
    {
        ActionsEnabled = false;
        ConfigurationUnitModel unit = CreateConfigurationUnitModel();
        await _dsc.Export(unit);
        ActionsEnabled = true;
    }
}
