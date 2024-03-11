
using ScannerControlMAUIApp.Core.API;
using ZebraBarcodeScannerSDK;

namespace ScannerControlMAUIApp.Core.Views;


public partial class ActiveScanner : ContentPage
{

    Scanner discoveredScanner;

    public ActiveScanner()
    {
        InitializeComponent();
        this.discoveredScanner = Globals.ConnectedScanner;
        lbScannerName.Text = Globals.ConnectedScanner.Name;
        SDKHandler.DeviceDisconnected += OnDeviceDisconnectedEventHandler;
    }

    // Handle disconect button action 
    private async void OnDisconnecBtnClicked(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert(ConstantsString.MsgDisconnectTitle, ConstantsString.MsgDisconnect, ConstantsString.MsgContinueAction, ConstantsString.MsgCancelAction);

        if (answer)
        {
            discoveredScanner.Disconnect();
        }

    }

    //Load asset info page when tapped "Asset Info" option
    private async void OnTapGestureRecognizerTappedAssetInfo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AssetInfoPage());
    }

    /// <summary>
    /// Event handler of Scanner Disconnected event
    /// </summary>
    /// <param name="obj">Object</param>
    /// <param name="args">Event Argument</param>
    private void OnDeviceDisconnectedEventHandler(object obj, EventArgs args)
    {
        Globals.IsScannerDisconnected = true;
        SDKHandler.ClearBarcodeList();
        Application.Current.Dispatcher.Dispatch(() =>
        {
            Navigation.PopAsync();
        });

    }

}
