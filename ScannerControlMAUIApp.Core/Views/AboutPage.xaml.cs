using ScannerControlMAUIApp.Core.API;

namespace ScannerControlMAUIApp.Core.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();

        lbSdkVersion.Text = SDKHandler.GetSdkVersion();

        lbAppVersion.Text = AppInfo.Current.VersionString;

        lbCopyright.Text = ConstantsString.CopyrightMsg;
    }
}
