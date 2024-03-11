using ScannerControlMAUIApp.Core.API;

namespace ScannerControlMAUIApp.Core.Views;

public partial class ScannerSettingsPage : ContentPage
{
    string xmlArgs = "<inArgs>";
    string xmlArgsEnd = "</inArgs>";
    string xmlScannerId = "<scannerID>";
    string xmlScannerIdEnd = "</scannerID>";

    public ScannerSettingsPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Action to turn on Scanner Aim
    /// </summary>
    private void AimOnAction(object sender, EventArgs e)
    {
        string inXml = xmlArgs + xmlScannerId + Globals.ConnectedScanner.Id + xmlScannerIdEnd + xmlArgsEnd;

        Globals.ConnectedScanner.ExecuteCommand(ZebraBarcodeScannerSDK.OpCode.DEVICE_AIM_ON, inXml);

    }

    /// <summary>
    /// Action to turn off Scanner Aim
    /// </summary>
    private void AimOffAction(object sender, EventArgs e)
    {
        string inXml = xmlArgs + xmlScannerId + Globals.ConnectedScanner.Id + xmlScannerIdEnd + xmlArgsEnd;

        Globals.ConnectedScanner.ExecuteCommand(ZebraBarcodeScannerSDK.OpCode.DEVICE_AIM_OFF, inXml);

    }

    /// <summary>
    /// Action to enable scanning
    /// </summary>
    private void EnableScanningAction(object sender, EventArgs e)
    {
        Globals.ConnectedScanner.EnableScanner();

    }

    /// <summary>
    /// Action to disable scanning
    /// </summary>
    private void DisableScanningAction(object sender, EventArgs e)
    {
        Globals.ConnectedScanner.DisableScanner();

    }


}
