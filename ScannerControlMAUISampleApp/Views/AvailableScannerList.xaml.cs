using ScannerControlMAUISampleApp.Model;
using ZebraBarcodeScannerSDK;
using ScannerControlMAUISampleApp.API;


namespace ScannerControlMAUISampleApp.Views;

public partial class AvailableScannerList : ContentPage
{
    public static List<ScannerModel> customScannerList = new List<ScannerModel>();
    int tappedRow = -1;

    public AvailableScannerList()
    {
        InitializeComponent();
        SDKHandler.ScannerAppearEvent += OnScannerAppearEventHandler;
        SDKHandler.DeviceDisappeared += OnDeviceDisappearedEventHandler;

        this.lsScaners.ItemsSource = null;
        customScannerList = SDKHandler.GetScanerList();
        lsScaners.ItemsSource = customScannerList;
    }


    /// <summary>
    /// Page Appearing
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
     
        this.lsScaners.ItemsSource = null;
        customScannerList = SDKHandler.GetScanerList();
        lsScaners.ItemsSource = customScannerList;
        HideLoadingIndicator();

        //Show successful disconnect msg 
        if (Globals.IsScannerDisconnected == true && Globals.DisconnectedScanerName != null)
        {
            DisplayAlert(ConstantsString.MsgConnectTitle, Globals.DisconnectedScanerName + ConstantsString.MsgDisconnected, ConstantsString.MsgActionOk);
            Globals.IsScannerDisconnected = false;
            Globals.DisconnectedScanerName = null;
        }
    }

    /// <summary>
    /// Page Disappearing
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        HideLoadingIndicator();

    }


    /// <summary>
    /// Event handler of scanner appear 
    /// </summary>
    /// <param name="scanner">Scanner object</param>
    private void OnScannerAppearEventHandler(Scanner scanner)
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            this.lsScaners.ItemsSource = null;

            customScannerList = SDKHandler.GetScanerList();
            lsScaners.ItemsSource = customScannerList;

        });

    }

    /// <summary>
    /// Event handler of Scanner Disappeared event
    /// </summary>
    /// <param name="obj">Object</param>
    /// <param name="args">Event Argument</param>
    private void OnDeviceDisappearedEventHandler(object obj, EventArgs args)
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            this.lsScaners.ItemsSource = null;
            customScannerList = SDKHandler.GetScanerList();
            lsScaners.ItemsSource = customScannerList;

        });
    }

    /// <summary>
    /// Selecte a scanner in Listview
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="tappedEventArg">Event Argument</param>
    private async void OnItemSelected(Object sender, ItemTappedEventArgs tappedEventArg)
    {

        tappedRow = tappedEventArg.ItemIndex;


        try
        {
            await Task.Run(() => ShowActivityIndicator())
                    .ContinueWith((connectingToScanner) =>
                    {
                        customScannerList[tappedEventArg.ItemIndex].ScannerObject.Connect();
                        Globals.ConnectedScanner = customScannerList[tappedEventArg.ItemIndex].ScannerObject;
                        Globals.ConnectedRow = tappedEventArg.ItemIndex;
                        Globals.ConnectedId = customScannerList[tappedEventArg.ItemIndex].Id;

                    });
        }

        catch (Exception e)
        {
            HideLoadingIndicator();
            await DisplayAlert(ConstantsString.Msg, ConstantsString.MsgUnableToCommunicate, ConstantsString.MsgActionOk);
            Console.WriteLine("Exception " + e.Message);
        }
    }


    /// <summary>
    /// Hide activity indicator
    /// </summary>
    protected void HideLoadingIndicator()
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
           
            lbConnectingStatus.IsVisible = false;
            listIndicator.IsRunning = false;
            listIndicator.IsVisible = false;

        });
    }

    /// <summary>
    /// Show activity indicator
    /// </summary>
    protected void ShowActivityIndicator()
    {
        Application.Current.Dispatcher.Dispatch(() =>
        {
            listIndicator.IsRunning = true;
            listIndicator.IsVisible = true;
            lbConnectingStatus.IsVisible = true;

        });

    }

}