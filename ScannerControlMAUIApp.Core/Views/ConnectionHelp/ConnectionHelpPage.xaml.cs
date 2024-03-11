using ScannerControlMAUIApp.Core.API;
using ScannerControlMAUIApp.Core.Model;

namespace ScannerControlMAUIApp.Core.Views.ConnectionHelp;

public partial class ConnectionHelpPage : ContentPage
{

    List<String> CS4070InstructionList = new List<String>(){
            ConstantsString.InstructionCS4070_1,
            ConstantsString.InstructionCS4070_2,
            ConstantsString.InstructionCS4070_3,
            ConstantsString.InstructionCS4070_4,
            ConstantsString.InstructionCS4070_5,
            ConstantsString.InstructionCS4070_6,
            ConstantsString.InstructionCS4070_7,
        };


    List<String> RFD8500InstructionList = new List<String>(){
            ConstantsString.InstructionRFD8500_1,
            ConstantsString.InstructionRFD8500_2,
            ConstantsString.InstructionRFD8500_3,
            ConstantsString.InstructionRFD8500_4,
            ConstantsString.InstructionRFD8500_5,
        };


    List<String> LIDS3678InstructionList = new List<String>(){
             ConstantsString.InstructionLIDS3678_1,
             ConstantsString.InstructionLIDS3678_2,
             ConstantsString.InstructionLIDS3678_3,
             ConstantsString.InstructionLIDS3678_4,
        };

    List<String> DS2278InstructionList = new List<String>(){
            ConstantsString.InstructionDS2278_1,
            ConstantsString.InstructionDS2278_2,
            ConstantsString.InstructionDS2278_3,
            ConstantsString.InstructionDS2278_4,
        };

    List<String> RS5100InstructionList = new List<String>(){

            ConstantsString.InstructionRS5100_1,
            ConstantsString.InstructionRS5100_2,
            ConstantsString.InstructionRS5100_3,
            ConstantsString.InstructionRS5100_4,
        };


    List<String> DefaultInstructionList = new List<String>(){
           ConstantsString.InstructionDefault

        };


    public ConnectionHelpPage()
    {
        InitializeComponent();
        Title = ConstantsString.TitleConnectionHelp;
        BindingContext = new HelpPairViewModel();
        NavigationPage.SetBackButtonTitle(this, ConstantsString.Back);
    }


    /// <summary>
    /// On Item Selected in listview
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="tappedEventArg">Event Argument</param>
    private void OnItemSelected(Object sender, ItemTappedEventArgs tappedEventArg)
    {

        if (tappedEventArg.ItemIndex == ConstantsString.Row1)
        {
#if __ANDROID__
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairRFD8500, RFD8500InstructionList));
#endif
#if __IOS__
                Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairCS4070, CS4070InstructionList));
#endif

        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row2)
        {
#if __ANDROID__
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.SetDefaults, DefaultInstructionList));
#endif
#if __IOS__
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairRFD8500, RFD8500InstructionList));
#endif

        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row3)
        {
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairLIDS3678, LIDS3678InstructionList));
        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row4)
        {
            Navigation.PushAsync(new MfiBtleSelectionPage(ConstantsString.PairDS8178CS6080));
        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row5)
        {
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairDS2278, DS2278InstructionList));
        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row6)
        {
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairRS5100, RS5100InstructionList));
        }
        else
        {
            Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.SetDefaults, DefaultInstructionList));
        }
    }
}
