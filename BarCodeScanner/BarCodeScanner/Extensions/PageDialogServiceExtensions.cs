using BarCodeScanner.Resources;
using Prism.Services;
using System.Threading.Tasks;

namespace BarCodeScanner.Extensions
{
    public static class PageDialogServiceExtensions
    {
        public static Task ShowAlert(this IPageDialogService dialogService, string message)
        {
            return dialogService.DisplayAlertAsync(AppResources.Alert, message, AppResources.Ok);
        }

        public static Task ShowSuccess(this IPageDialogService dialogService, string message)
        {
            return dialogService.DisplayAlertAsync(AppResources.Success, message, AppResources.Ok);
        }

        public static Task ShowError(this IPageDialogService dialogService, string message)
        {
            return dialogService.DisplayAlertAsync(AppResources.Error, message, AppResources.Ok);
        }

        public static Task<bool> Confirm(this IPageDialogService dialogService, string message)
        {
            return dialogService.DisplayAlertAsync(AppResources.Confirm, message, AppResources.Yes, AppResources.No);
        }
    }
}
