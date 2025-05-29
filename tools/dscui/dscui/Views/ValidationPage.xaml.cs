using dscui.Contracts.Views;
using dscui.Models;
using dscui.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using static System.Net.Mime.MediaTypeNames;

namespace dscui.Views;

public sealed partial class ValidationPage : Page, IView<ValidationViewModel>
{
    public ValidationViewModel ViewModel => DataContext as ValidationViewModel;

    private ValidationListViewModel _validationListViewModel;

    public ValidationPage()
    {
        System.Diagnostics.Debug.WriteLine("Creating new ValidationPage");
        _validationListViewModel = App.GetService<ValidationListViewModel>();
        InitializeComponent();
    }
    private void ValidationPropertyNameTextChanged(object sender, TextChangedEventArgs e)
    {
        //ViewModel = _validationListViewModel.GetCurrentViewModel();
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            if (textBox.DataContext is ConfigurationProperty p)
            {
                p.Name = textBox.Text;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DataContext is null");
            }
        }
    }
    private void ValidationPropertyValueTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (textBox.DataContext is ConfigurationProperty p)
            {
                switch (p.Value.Type)
                {
                    case PropertyType.String:
                        p.Value = new StringValue(textBox.Text);
                        break;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DataContext is null");
            }
        }
    }
    private void NewValidationPropertyDefault(SplitButton sender, SplitButtonClickEventArgs e)
    {
        ViewModel.Properties.Add(new("", new StringValue("")));
    }
    private void NewValidationProperty(object sender, RoutedEventArgs e)
    {
        if (sender is MenuFlyoutItem item && item.Tag is string tag)
        {
            switch (tag)
            {
                case "Str":
                    ViewModel.Properties.Add(new("", new StringValue("")));
                    break;
                case "Num":
                    ViewModel.Properties.Add(new("", new NumberValue(0)));
                    break;
                case "Bool":
                    ViewModel.Properties.Add(new("", new BooleanValue(false)));
                    break;
                case "Arr":
                    ViewModel.Properties.Add(new("", new ArrayValue(new List<ConfigurationPropertyValueBase>())));
                    break;
                case "Obj":
                    ViewModel.Properties.Add(new("", new ObjectValue(new List<ConfigurationProperty>())));
                    break;
            }
        }
    }

    private void RemoveValidationProperty(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if(button != null)
        {
            if(button.DataContext is ConfigurationProperty property)
            {
                ViewModel.Properties.Remove(property);
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