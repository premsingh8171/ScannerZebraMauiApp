using ScannerControlMAUISampleApp.API;
using ScannerControlMAUISampleApp.Model;
using ZebraBarcodeScannerSDK;

namespace ScannerControlMAUISampleApp.Views;

public partial class BarcodeDataPage : ContentPage
{
    List<BarcodeModel> reverseBarcodeList = new List<BarcodeModel>();
    IList<BarcodeModel> barcodeList = SDKHandler.GetBarcodeList();

    public BarcodeDataPage()
	{
		InitializeComponent();
        SDKHandler.BarcodeDataEvent += BarcodeDataReceivedEvent;
    }


    /// <summary>
    /// Page Appearing
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Globals.IsBarcodeDetailPageLoaded = true;
        this.BarcodeDataReceivedEvent(null, -1);
    }
    /// <summary>
    /// Page Disappearing
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Globals.IsBarcodeDetailPageLoaded = false;
    }



    /// <summary>
    /// Event handler of barcode data event
    /// </summary>
    /// <param name="barcodeData"> Barcode data</param>
    /// param name="scannerID">scanner ID</param>
    private void BarcodeDataReceivedEvent(BarcodeData barcodeData, int scannerID)
    {

        Application.Current.Dispatcher.Dispatch(() =>
        {

            this.lstBarcodes.ItemsSource = null;
            barcodeList = SDKHandler.GetBarcodeList();
            reverseBarcodeList = new List<BarcodeModel>(barcodeList);
            reverseBarcodeList.Reverse();

            lstBarcodes.ItemsSource = reverseBarcodeList;
            

        });
    }

    /// <summary>
    /// Select a barcode in Listview
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="tappedEventArg">Event Argument</param>
    private void OnItemSelected(Object sender, ItemTappedEventArgs tappedEventArg)
    {
        Navigation.PushAsync(new BarcodeDetailsPage(reverseBarcodeList[tappedEventArg.ItemIndex]));
    }


}
