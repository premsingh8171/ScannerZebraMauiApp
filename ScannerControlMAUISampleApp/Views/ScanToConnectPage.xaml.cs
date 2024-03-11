using ScannerControlMAUISampleApp.API;
using ScannerControlMAUISampleApp.Views;
using ZebraBarcodeScannerSDK;
#if __ANDROID__
using ScannerControlMAUISampleApp.Platforms.Android;
#endif

namespace ScannerControlMAUISampleApp;

public partial class ScanToConnectPage : ContentPage
{

    public ScanToConnectPage()
    {
        InitializeComponent();

        //SDKHandler.ScannerAppearEvent += OnScannerAppearEventHandler;
        //SDKHandler.DeviceDisappeared += OnDeviceDisappearedEventHandler;
        SDKHandler.DeviceConnected += OnDeviceConnectedEventHandler;
        //SDKHandler.DeviceDisconnected += OnDeviceDisconnectedEventHandler;


    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

#if __ANDROID__

        if (!await CheckPermissions())
        {
            Application.Current.Quit();
        }
#endif
        Globals.isScanToConnectPageLoaded = true;
        STCBarcodeDraw();

        //Show successful disconnect msg 
        if (Globals.IsScannerDisconnected == true && Globals.DisconnectedScanerName != null)
        {
            await DisplayAlert(ConstantsString.MsgConnectTitle, Globals.DisconnectedScanerName + ConstantsString.MsgDisconnected, ConstantsString.MsgActionOk);
            Globals.IsScannerDisconnected = false;
            Globals.DisconnectedScanerName = null;
        }

    }



#if __ANDROID__

    //Check status of Android runtime permissions
    private async Task<bool> CheckPermissions()
    {
        PermissionStatus bluetoothStatus = await CheckBluetoothPermissions();


        return IsGranted(bluetoothStatus);
    }

    //Checking the permission status on version vise
    private async Task<PermissionStatus> CheckBluetoothPermissions()
    {
        PermissionStatus bluetoothStatus = PermissionStatus.Granted;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            if (DeviceInfo.Version.Major >= 12)
            {
                bluetoothStatus = await CheckPermissions<BluetoothPermissionsUpper>();
            }
            else
            {
                bluetoothStatus = await CheckPermissions<BluetoothPermissionsLower>();
            }
        }

        return bluetoothStatus;
    }

    //Check status for all the permissions at once
    private async Task<PermissionStatus> CheckPermissions<TPermission>() where TPermission : Permissions.BasePermission, new()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<TPermission>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<TPermission>();
        }

        return status;
    }


    //Get permission grant status
    private static bool IsGranted(PermissionStatus status)
    {
        return status == PermissionStatus.Granted || status == PermissionStatus.Limited;
    }

#endif


    /// <summary>
    /// Generate stc barcode 
    /// </summary>
    private void STCBarcodeDraw()
    {
        SDKHandler.SetSTCEnabledState(true);
        SDKHandler.EnableBluetoothScannerDiscovery();


        ///Default configurations
        PairingBarcodeType barcodeType = PairingBarcodeType.BARCODE_TYPE_STC;
        ScannerConfiguration scannerConfiguration = ScannerConfiguration.KEEP_CURRENT;
        BluetoothProtocol bluetoothProtocol = BluetoothProtocol.SSI_BT_LE;
        string bluetoothMacAddress = "";

#if __ANDROID__
        //If bluetooth address is set
        if (Preferences.ContainsKey(ConstantsString.BluetoothMacAddressStoringKey))
        {
            bluetoothMacAddress = Preferences.Get(ConstantsString.BluetoothMacAddressStoringKey, "").ToString();
        } else
        {
            //If bluetooth address is not set, change the communication protocol to BLE
            Preferences.Set(ConstantsString.ComProtocol, ConstantsString.ComProtocolBLE.ToString());
        }
#endif


        // If SetFactoryDefault preferences are set
        if (Preferences.ContainsKey(ConstantsString.SetFactoryDefaults))
        {
            string setDefaults = Preferences.Get(ConstantsString.SetFactoryDefaults, "").ToString();

            if (setDefaults == ScannerConfiguration.KEEP_CURRENT.ToString())
            {
                scannerConfiguration = ScannerConfiguration.KEEP_CURRENT;
            }
            else if (setDefaults == ScannerConfiguration.SET_FACTORY_DEFAULTS.ToString())
            {
                scannerConfiguration = ScannerConfiguration.SET_FACTORY_DEFAULTS;
            }
        }
        else
        {

#if __ANDROID__
            //Set default configuration preferences
            Preferences.Set(ConstantsString.SetFactoryDefaults, ScannerConfiguration.SET_FACTORY_DEFAULTS.ToString());
#endif

#if __IOS__
            //Set default configuration preferences
            Preferences.Set(ConstantsString.SetFactoryDefaults, ScannerConfiguration.KEEP_CURRENT.ToString());
#endif
        }

        // If communication protocol references are set
        if (Preferences.ContainsKey(ConstantsString.ComProtocol))
        {


#if __ANDROID__

            if (Preferences.Get(ConstantsString.ComProtocol, "").ToString() == BluetoothProtocol.SSI_BT_CRADLE_HOST.ToString())
            {
                bluetoothProtocol = BluetoothProtocol.SSI_BT_CRADLE_HOST;
            }
            else
            {
                bluetoothProtocol = BluetoothProtocol.SSI_BT_LE;
            }


#endif

        }
        else
        {
            //Set default protocol preferences
            Preferences.Set(ConstantsString.ComProtocol, BluetoothProtocol.SSI_BT_LE.ToString());
        }

        if (SDKHandler.GetInstance() != null)
        {
            byte[] imageData;
            if (bluetoothProtocol == BluetoothProtocol.SSI_BT_LE)
            {
                imageData = SDKHandler.GetBluetoothParingBarcode(barcodeType, bluetoothProtocol, scannerConfiguration);
            }
            else
            {
                SDKHandler.SetOperationModeOnAppSetting(OpMode.OPMODE_SSI);
                imageData = SDKHandler.GetBluetoothParingBarcode(barcodeType, bluetoothProtocol, scannerConfiguration, bluetoothMacAddress);
            }


#if __ANDROID__
            System.Diagnostics.Debug.WriteLine("TEST Mode: ---------------------------" + Preferences.Get(ConstantsString.ModeTypeStoringKey, "").ToString());

            //ReSizingImageForAndroidDevice(imageData);

#endif
#if __IOS__
            stcImage.Source = ImageSource.FromStream(() => new MemoryStream(imageData));
#endif

        }
    }

    /// <summary>
    /// Resize the image for android device
    /// </summary>
    /// <param name="imageData">The image data</param>
/*    private void ReSizingImageForAndroidDevice(Byte[] imageData)
    {

        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        var width = mainDisplayInfo.Width - 100;
        var height = mainDisplayInfo.Height;

        stcImage.HorizontalOptions = LayoutOptions.Center;
        stcImage.Aspect = Aspect.AspectFit;

        var resizeWidth = width * 9 / 10;
        var resizeHeight = resizeWidth / 3;
        if (width > ConstantsString.SixInchScreen)
        {
            resizeWidth = ((width + 200) * 2 / 7);
            resizeHeight = (resizeWidth) / 3;
            //  byte[] imageDataResize = ImageResizer.ResizeImage(imageData, (float)resizeWidth, (float)resizeHeight);
            stcImage.WidthRequest = resizeWidth;
            stcImage.HeightRequest = resizeHeight;

            //  stcImage.Source = ImageSource.FromStream(() => new MemoryStream(imageDataResize));
        }
        else
        {
            stcImage.WidthRequest = resizeWidth;
            stcImage.HeightRequest = resizeHeight;
            stcImage.TranslateTo(Convert.ToDouble((imageData.Length / ConstantsString.ImageDataDevider) + ConstantsString.XaxisMove), ConstantsString.YaxisMove, ConstantsString.Movement);
            stcImage.Scale = ConstantsString.ScaleSize;
            stcImage.Source = ImageSource.FromStream(() => new MemoryStream(imageData));
        }



    }
*/
    /// <summary>
    /// On disappearing event
    /// </summary>
    protected override void OnDisappearing()
    {
        Globals.isScanToConnectPageLoaded = false;
    }


    /// <summary>
    /// Event handler of Scanner Connected event
    /// </summary>
    /// <param name="obj">Object</param>
    /// <param name="args">Argument Event</param>
    private void OnDeviceConnectedEventHandler(object obj, EventArgs args)
    {
        Globals.IsScannerDisconnected = false;
        Globals.ConnectedScanner = (Scanner)obj;

        Application.Current.Dispatcher.Dispatch(() =>
        {
            Navigation.PushAsync(new TabPage());
            DisplayAlert(ConstantsString.MsgConnectTitle, Globals.ConnectedScanner.Name + ConstantsString.MsgConnected, ConstantsString.MsgActionOk);
        });

    }

    //On Settings action navigating to the settings page
    private void OnSettingsClicked(object sender, EventArgs e)
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            Navigation.PushAsync(new MorePage());

        });

    }
}
