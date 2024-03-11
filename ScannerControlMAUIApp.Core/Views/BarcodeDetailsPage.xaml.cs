using ScannerControlMAUIApp.Core.API;
using ScannerControlMAUIApp.Core.Model;
using ZebraBarcodeScannerSDK;

namespace ScannerControlMAUIApp.Core.Views;

public partial class BarcodeDetailsPage : ContentPage
{
    public BarcodeDetailsPage(BarcodeModel barcodeModel)
    {
        InitializeComponent();

        //lbScannerId.Text = barcodeModel.ScannerID.ToString();
        lbBarcodeType.Text = barcodeModel.BarcodeType;
        lbBacodeData.Text = barcodeModel.DecodeData;
        SDKHandler.BarcodeDataEvent += BarcodeDataReceivedEvent;
    }


    /// <summary>
    /// Event handler of  Barcode Data
    /// </summary>
    /// <param name="barcodeData">Barcode Data</param>
    /// <param name="scannerID">Scanner Id</param>
    private void BarcodeDataReceivedEvent(BarcodeData barcodeData, int scannerID)
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            Navigation.PopAsync();
        });
    }
}
