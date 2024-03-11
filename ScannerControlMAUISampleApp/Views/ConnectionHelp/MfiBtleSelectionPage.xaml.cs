using ScannerControlMAUISampleApp.API;
using ScannerControlMAUISampleApp.Model;


namespace ScannerControlMAUISampleApp.Views.ConnectionHelp;

public partial class MfiBtleSelectionPage : ContentPage
{

    List<String> CS6080DS8178BTLEInstructionList = new List<String>(){
             ConstantsString.InstructionCS6080DS8178BTLE_1,
             ConstantsString.InstructionCS6080DS8178BTLE_2,
             ConstantsString.InstructionCS6080DS8178BTLE_3,
             ConstantsString.InstructionCS6080DS8178BTLE_4,

        };

    List<String> CS6080DS8178MFIInstructionList = new List<String>(){
             ConstantsString.InstructionCS6080DS8178MFI_1,
             ConstantsString.InstructionCS6080DS8178MFI_2,
             ConstantsString.InstructionCS6080DS8178MFI_3,
             ConstantsString.InstructionCS6080DS8178MFI_4,
             ConstantsString.InstructionCS6080DS8178MFI_5,
             ConstantsString.InstructionCS6080DS8178MFI_6,
             ConstantsString.InstructionCS6080DS8178MFI_7

        };

    public MfiBtleSelectionPage(string title)
    {
		InitializeComponent();
        this.Title = title;
        NavigationPage.SetBackButtonTitle(this, ConstantsString.Back);
        BindingContext = new HelpViewModel();
    }

    /// <summary>
    /// On Item Selected in listview
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="tappedEventArg">Event Argument</param>
    private async void OnItemSelected(Object sender, ItemTappedEventArgs tappedEventArg)
    {
        if (tappedEventArg.ItemIndex == ConstantsString.Row1)
        {

            await Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairCS6080DS8178BTLE, CS6080DS8178BTLEInstructionList));
            

        }
        else if (tappedEventArg.ItemIndex == ConstantsString.Row2)
        {


            await Navigation.PushAsync(new ConnectionHelpDetailPage(ConstantsString.PairCS6080DS8178MFI, CS6080DS8178MFIInstructionList));
            
        }
    }

}
