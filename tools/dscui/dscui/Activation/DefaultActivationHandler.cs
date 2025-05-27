using dscui.Contracts.Services;
using dscui.ViewModels;

using Microsoft.UI.Xaml;

namespace dscui.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly IAppNavigationService _navigationService;

    public DefaultActivationHandler(IAppNavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.NavigateTo<MainViewModel>(args.Arguments);

        await Task.CompletedTask;
    }
}
