using ScannerControlMAUIApp.Core.API;
using System.Text.RegularExpressions;
using ZebraBarcodeScannerSDK;

#if __ANDROID__

using Android.OS;

#endif
namespace ScannerControlMAUIApp.Core.Views;

public partial class AppSettingsPage : ContentPage
{
    string bluetoothAddress = "";
    string previousMac = "";


    public AppSettingsPage()
    {
        InitializeComponent();
#if __ANDROID__
       
         LoadBluetoothAddress();
#endif
        LoadingComProtocol();
        LoadDefaultConfiguration();
        BindingContext = new BluetoothProtocolModel();

    }


    /// <summary>
    /// Set factory default configuration on the ui
    /// </summary>
    private void LoadDefaultConfiguration()
    {
        if (Preferences.ContainsKey(ConstantsString.SetFactoryDefaults))
        {

            if (Preferences.Get(ConstantsString.SetFactoryDefaults, "").Equals(ScannerConfiguration.SET_FACTORY_DEFAULTS.ToString()))
            {
                factoryDefaultToggle.IsToggled = true;
            }
            else
            {
                factoryDefaultToggle.IsToggled = false;
            }
        }

    }


    /// <summary>
    /// Method to load saved preferences to get communication protocols and set up UI
    /// </summary>
    private void LoadingComProtocol()
    {
        bluetoothAddressInputLayout.IsVisible = false;

#if __ANDROID__
        communicationProtocolPicker.IsVisible = true;
         communicationModeStack.IsVisible = false;
        if (Preferences.ContainsKey(ConstantsString.ComProtocol))
        {
            string comProtocol = Preferences.Get(ConstantsString.ComProtocol, null).ToString();


            if (comProtocol == BluetoothProtocol.SSI_BT_CRADLE_HOST.ToString())
            {
                communicationProtocolPicker.SelectedIndex = 0;
                communicationProtocolPicker.Title = ConstantsString.ComProtocolCLASSIC;
                bluetoothAddressInputLayout.IsVisible = true;
            }
            else
            {
                communicationProtocolPicker.SelectedIndex = 1;
                communicationProtocolPicker.Title = ConstantsString.ComProtocolBLE;
                bluetoothAddressInputLayout.IsVisible = false;
            }

        }

#endif
#if __IOS__

        communicationProtocolPicker.IsVisible = false;
        communicationProtocolLabel.IsVisible = false;
        bluetoothAddressInputLayout.IsVisible = false;
        communicationModeStack.IsVisible = true;
        communicationProtocolPicker.Title = "MFI + BT LE";
        SDKHandler.SetOperationModeOnAppSetting(OpMode.OPMODE_MFI_BTLE);
#endif



    }

    /// <summary>
    /// Communication protocol changed action
    /// </summary>
    void OnCommunicationProtocolChanged(object sender, EventArgs eventArgs)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        bluetoothAddressInputLayout.IsVisible = false;

#if __ANDROID__
        if (selectedIndex == 0)
        {
            Preferences.Set(ConstantsString.ComProtocol, BluetoothProtocol.SSI_BT_CRADLE_HOST.ToString());
            bluetoothAddressInputLayout.IsVisible = true;
            Preferences.Set(ConstantsString.ModeTypeStoringKey, ConstantsString.SSI);
            SDKHandler.SetOperationModeOnAppSetting(OpMode.OPMODE_SSI);
        }
        else
        {
            Preferences.Set(ConstantsString.ComProtocol, BluetoothProtocol.SSI_BT_LE.ToString());
            Preferences.Set(ConstantsString.ModeTypeStoringKey, ConstantsString.BTLE);
            SDKHandler.SetOperationModeOnAppSetting(OpMode.OPMODE_BTLE);
        }


#endif

    }

    /// <summary>
    /// Factory default toggle action
    /// </summary>
    void OnFactoryDefaultToggle(object sender, ToggledEventArgs toggledEventArgs)
    {
        if (toggledEventArgs.Value)
        {
            Preferences.Set(ConstantsString.SetFactoryDefaults, ScannerConfiguration.SET_FACTORY_DEFAULTS.ToString());
        }
        else
        {
            Preferences.Set(ConstantsString.SetFactoryDefaults, ScannerConfiguration.KEEP_CURRENT.ToString());
        }
    }




    /// <summary>
    /// Bluetooth address text input changed action
    /// </summary>
    void OnBluetoothAddressChanged(object sender, TextChangedEventArgs textChangeEvent)
    {
#if __ANDROID__
        var enteredMACAddress = textChangeEvent.NewTextValue.ToUpper(); //767

        string cleanMACAddressWithColons = CleanIncorrectMACAddress(enteredMACAddress); //767
        string cleanMacAddress = RemoveIncorrectColonCharcters(cleanMACAddressWithColons);
        if (!previousMac.Equals(cleanMacAddress) && cleanMacAddress.Length < ConstantsString.BluetoothMacAddressLength && !cleanMacAddress.Equals(""))
        {
            string bluetoothMacAddress = "";
            for (int i = 0; i < cleanMacAddress.Length; i++)
            {
                if (i % 3 == 2 && cleanMacAddress[i] != ConstantsString.BluetoothMacAddressColon)
                {
                    bluetoothMacAddress += ConstantsString.BluetoothMacAddressColon;

                }
                else if (i % 3 == 2 && cleanMacAddress[i] == ConstantsString.BluetoothMacAddressColon)
                {

                }

                bluetoothMacAddress += cleanMacAddress[i];
            }
            previousMac = bluetoothMacAddress;
            SetBluetoothAddressTxt(bluetoothMacAddress);

        }
        else if (cleanMacAddress.Length > 16)
        {
            bluetoothAddressInput.Unfocus();

            Preferences.Set(ConstantsString.BluetoothMacAddressStoringKey, cleanMacAddress);

        }

#endif
    }

#if __ANDROID__


   /// <summary>
    /// Set bluetooth address when loading the ui
    /// </summary>
    private void LoadBluetoothAddress()
    {
        if (Preferences.ContainsKey(ConstantsString.BluetoothMacAddressStoringKey))
        {

            bluetoothAddress = Preferences.Get(ConstantsString.BluetoothMacAddressStoringKey, "").ToString();
            SetBluetoothAddressTxt(bluetoothAddress);
        } else
        {
            Preferences.Set(ConstantsString.ComProtocol, ConstantsString.ComProtocolBLE.ToString());
            SDKHandler.SetOperationModeOnAppSetting(OpMode.OPMODE_BTLE);
            LoadingComProtocol();
        }

    }



    /// <summary>
    /// Clean incorrect colon characters from inserted text
    /// </summary>
    /// <param name="cleanMACAddressWithColons">User typed mac address</param>
    /// <returns>Filtered mac address</returns>
    private string RemoveIncorrectColonCharcters(string cleanMACAddressWithColons)
    {
        string cleanMacAddress = "";
        if (!cleanMACAddressWithColons.Equals(cleanMacAddress))
        {
            if (cleanMACAddressWithColons[cleanMACAddressWithColons.Length - 1].Equals(ConstantsString.BluetoothMacAddressColon))
            {
                cleanMacAddress = cleanMACAddressWithColons.Remove(cleanMACAddressWithColons.Length - 1);
                SetBluetoothAddressTxt(cleanMacAddress);
                return cleanMacAddress;
            }
            else
            {
                return cleanMACAddressWithColons;
            }
        }
        else
        {
            return cleanMACAddressWithColons;
        }


    }

    /// <summary>
    /// Clean incorrect MAC address characters from inserted text
    /// </summary>
    /// <param name="enteredMACAddress">User typed mac address</param>
    /// <returns>Filtered mac address</returns>
    private string CleanIncorrectMACAddress(string enteredMACAddress)
    {

        if ((Regex.IsMatch(enteredMACAddress, ConstantsString.BluetoothMacAddressRegex)) || enteredMACAddress.Length > ConstantsString.BluetoothMacAddressLength)
        {
            enteredMACAddress = enteredMACAddress.Remove(enteredMACAddress.Length - 1);
            SetBluetoothAddressTxt(enteredMACAddress);
            return enteredMACAddress;
        }
        else
        {
            return enteredMACAddress;

        }
    }

    /// <summary>
    /// Set bluetooth mac address
    /// </summary>
    /// <param name="bluetoothMacAddress">Completed bluetooth mac address</param>
    ///



    private void SetBluetoothAddressTxt(string bluetoothMacAddress)
    {
        bluetoothAddressInput.TextChanged -= OnBluetoothAddressChanged;
        bluetoothAddressInput.Text = bluetoothMacAddress;
        bluetoothAddressInput.TextChanged += OnBluetoothAddressChanged;

        //Resetting the cursor position to fix the MAUI cursor jumping
        //issue on Android platform which is still present in the MAUI latest release
        var looper = Looper.MyLooper();
        if (looper != null)
        {
            var handler = new Handler(looper);
            handler.Post(() =>
            {
                bluetoothAddressInput.CursorPosition = bluetoothAddressInput.Text.Length;
            });
        }else
        {
            bluetoothAddressInput.CursorPosition = bluetoothAddressInput.Text.Length;
        }
    }

#endif
    /// <summary>
    /// Bluetooth address text input completed action
    /// </summary>
    void BluetoothAddressUpdated(object sender, EventArgs e)
    {
#if __ANDROID__

        Preferences.Set(ConstantsString.BluetoothMacAddress, bluetoothAddressInput.Text);

#endif
    }




    /// <summary>
    /// Set operation mode for the scanner
    /// </summary>
    /// <param name="opMode">Operation Mode</param>
    private void SetOperationModeInAppSetting(OpMode opMode)
    {
        if (SDKHandler.GetInstance() != null)
        {
            SDKHandler.SetOperationModeOnAppSetting(opMode);
        }
    }

}


/// <summary>
/// BluetoothProtocolModel to set the bluetooth protocol list in the picker view
/// </summary>
public class BluetoothProtocolModel
{

#if __ANDROID__
    public IList<object> BluetoothProtocol { get; } = new List<object> { ConstantsString.ComProtocolCLASSIC, ConstantsString.ComProtocolBLE };

#endif
#if __IOS__
    public IList<object> BluetoothProtocol { get; } = new List<object>{ ConstantsString.MFI_BTLE };
#endif

}
