using System.Collections.ObjectModel;
using dscui.Contracts.Services;
using dscui.Contracts.Views;
using dscui.Models;
using dscui.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.ApplicationModel.DataTransfer;

namespace dscui.Views;

public sealed partial class ValidationPage : Page, IView<ValidationViewModel>
{
    public ValidationViewModel ViewModel { get; }
    private readonly IValidationFlowService _validationFlowService;

    public ValidationPage()
    {
        _validationFlowService = App.GetService<IValidationFlowService>();
        ViewModel = _validationFlowService.ValidationViewModels[_validationFlowService.CurrentTabIndex];
        DataContext = ViewModel;
        InitializeComponent();
    }
    private void NewValidationPropertyDefault(SplitButton sender, SplitButtonClickEventArgs e)
    {
        ObservableCollection<ConfigurationProperty>? l = null;
        if (sender.DataContext is ConfigurationProperty p && p.Value.Value is ObservableCollection<ConfigurationProperty> l1)
        {
            l = l1;
        }
        else if (sender.DataContext is ConfigurationPropertyValueBase v && v.Value is ObservableCollection<ConfigurationProperty> l2)
        {
            l = l2;
        }
        l ??= ViewModel.Properties;
        l.Add(new("", new StringValue("")));
    }
    private void NewValidationValueDefault(SplitButton sender, SplitButtonClickEventArgs e)
    {
        ObservableCollection<ConfigurationPropertyValueBase>? l = null;
        if (sender.DataContext is ConfigurationProperty p && p.Value.Value is ObservableCollection<ConfigurationPropertyValueBase> l1)
        {
            l = l1;
        }
        else if (sender.DataContext is ConfigurationPropertyValueBase v && v.Value is ObservableCollection<ConfigurationPropertyValueBase> l2)
        {
            l = l2;
        }
        if(l != null)
        {
            l.Add(new StringValue(""));
        }
    }
    private void NewValidationProperty(object sender, RoutedEventArgs e)
    {
        if (sender is MenuFlyoutItem item && item.Tag is string tag)
        {
            ObservableCollection<ConfigurationProperty>? l = null;
            if (item.DataContext is ConfigurationProperty p && p.Value.Value is ObservableCollection<ConfigurationProperty> l1)
            {
                l = l1;
            }
            else if (item.DataContext is ConfigurationPropertyValueBase v && v.Value is ObservableCollection<ConfigurationProperty> l2)
            {
                l = l2;
            }
            l ??= ViewModel.Properties;
            switch (tag)
            {
                case "Str":
                    l.Add(new("", new StringValue("")));
                    break;
                case "Num":
                    l.Add(new("", new NumberValue(0)));
                    break;
                case "Bool":
                    l.Add(new("", new BooleanValue(false)));
                    break;
                case "Arr":
                    l.Add(new("", new ArrayValue(new ObservableCollection<ConfigurationPropertyValueBase>())));
                    break;
                case "Obj":
                    l.Add(new("", new ObjectValue(new ObservableCollection<ConfigurationProperty>())));
                    break;
            }
        }
    }

    private void NewValidationValue(object sender, RoutedEventArgs e)
    {
        if (sender is MenuFlyoutItem item && item.Tag is string tag)
        {
            ObservableCollection<ConfigurationPropertyValueBase>? l = null;

            if (item.DataContext is ConfigurationProperty p && p.Value.Value is ObservableCollection<ConfigurationPropertyValueBase> l1)
            {
                l = l1;
            }
            else if (item.DataContext is ConfigurationPropertyValueBase v && v.Value is ObservableCollection<ConfigurationPropertyValueBase> l2)
            {
                l = l2;
            }

            if (l != null)
            {
                switch (tag)
                {
                    case "Str":
                        l.Add(new StringValue(""));
                        break;
                    case "Num":
                        l.Add(new NumberValue(0));
                        break;
                    case "Bool":
                        l.Add(new BooleanValue(false));
                        break;
                    case "Arr":
                        l.Add(new ArrayValue(new ObservableCollection<ConfigurationPropertyValueBase>()));
                        break;
                    case "Obj":
                        l.Add(new ObjectValue(new ObservableCollection<ConfigurationProperty>()));
                        break;
                }
            }
        }
    }

    private void RemoveValidationProperty(object sender, RoutedEventArgs e)
    {
        
        var button = sender as Button;
        if (button != null)
        {
            var parent = VisualTreeHelper.GetParent(button);
            while(parent != null && parent is not ListView)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is ListView lv
                && lv.ItemsSource is ObservableCollection<ConfigurationProperty> l
                && button.DataContext is ConfigurationProperty p)
            {
                l.Remove(p);
            }
        }
    }

    private void RemoveValidationValue(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            var parent = VisualTreeHelper.GetParent(button);
            while (parent != null && parent is not ListView)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is ListView lv
                && lv.ItemsSource is ObservableCollection<ConfigurationPropertyValueBase> l
                && button.DataContext is ConfigurationPropertyValueBase p)
            {
                l.Remove(p);
            }
        }
    }
    private void CopyToClipboard(object sender, RoutedEventArgs e)
    {
        var dataPackage = new DataPackage();
        dataPackage.SetText(ViewModel.RawData);
        Clipboard.SetContent(dataPackage);
    }
}