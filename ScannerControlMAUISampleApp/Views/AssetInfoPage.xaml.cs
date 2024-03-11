using ScannerControlMAUISampleApp.API;
using ZebraBarcodeScannerSDK;

namespace ScannerControlMAUISampleApp.Views;

public partial class AssetInfoPage : ContentPage
{
    Scanner discoverdScanner;
    string scannerModeType;

    public AssetInfoPage()
	{
		InitializeComponent();
        Title = ConstantsString.AssertInfoTitle;
        this.discoverdScanner = Globals.ConnectedScanner;
        this.scannerModeType = SDKHandler.GetScannerCommunicationProtocol(Globals.ConnectedScanner);
        LoadAssetInfo();
    }

    /// <summary>
    /// Load asset information
    /// </summary>
    private void LoadAssetInfo()
    {
        try
        {
            AssetInformation assetInformation = discoverdScanner.ScannerAssetInformation();
            lbConfiguration.Text = assetInformation.ConfigurationName.Trim();
            lbSerialNo.Text = assetInformation.SerialNumber.Trim();
            lbModel.Text = assetInformation.ModelNumber.Trim();
            lbFirmware.Text = assetInformation.FirmwareVersion.Trim();
            lbDoM.Text = assetInformation.ManufacturedDate.Trim();
            lbMode.Text = scannerModeType;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception " + e.Message);
        }

    }
}
