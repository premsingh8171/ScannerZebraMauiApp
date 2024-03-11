using Microsoft.Maui.Controls;
using ScannerControlMAUISampleApp.API;
using ScannerControlMAUISampleApp.Model;
using ScannerControlMAUISampleApp.Views.ConnectionHelp;

namespace ScannerControlMAUISampleApp.Views;

public partial class MorePage : ContentPage
{
    public MorePage()
    {
        InitializeComponent();
        BindingContext = new MenuItemViewModel();
    }

    /// <summary>
    /// OnItemSelected in listview
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="tappedEventArg">Event argument</param>
    private void OnItemSelected(Object sender, ItemTappedEventArgs tappedEventArg)
    {

        Application.Current.Dispatcher.Dispatch(() =>
        {

            if (tappedEventArg.ItemIndex == ConstantsString.Row1)
            {
                Navigation.PushAsync(new AvailableScannerList());

            }
            else if (tappedEventArg.ItemIndex == ConstantsString.Row2)
            {
                Navigation.PushAsync(new ConnectionHelpPage());
                
            }
            else if (tappedEventArg.ItemIndex == ConstantsString.Row3)
            {
                Navigation.PushAsync(new AppSettingsPage());


            }
            else
            {

                Navigation.PushAsync(new AboutPage());
            }

        });

    }
}