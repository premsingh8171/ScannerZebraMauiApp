using ZebraBarcodeScannerSDK;
using ScannerControlMAUISampleApp.API;

namespace ScannerControlMAUISampleApp.Views;

public partial class TabPage : TabbedPage
{
	public TabPage()
    {
		InitializeComponent();
        SDKHandler.BarcodeDataEvent += OnBarcodeDataRecived;
    }


    /// <summary>
    /// Event handler of  Barcode Data
    /// </summary>
    /// <param name="barcodeData">Barcode Data</param>
    /// <param name="scannerID">Scanner Id</param>
    private void OnBarcodeDataRecived(BarcodeData barcodeData, int scannerID)
    {

        if ( !(Globals.IsBarcodeDetailPageLoaded))
        {

            NavigateToBarcodePage();
    
        }
    }

    public void NavigateToBarcodePage()
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            CurrentPage = Children[1];
        });

    }
}
