using ScannerControlMAUIApp.Core.API;

namespace ScannerControlMAUIApp.Core.Views.ConnectionHelp;

public partial class ConnectionHelpDetailPage : ContentPage
{
    public ConnectionHelpDetailPage(String title, List<String> instructionsList)
    {
        InitializeComponent();
        this.Title = title;
        myscrollview.ScrollToAsync(teststack, ScrollToPosition.Start, true);

        if (this.Title == ConstantsString.PairCS4070)
        {
            img2.Source = ImageSource.FromFile("cs4070factorysetdefault.png");
            img3.Source = ImageSource.FromFile("cs4070mfissibarcode.png");
        }
        else if (this.Title == ConstantsString.PairCS6080DS8178BTLE)
        {
            img2.Source = ImageSource.FromFile(ConstantsString.ImgEmpty);
            img3.Source = ImageSource.FromFile(ConstantsString.ImgEmpty);
        }
        else if (this.Title == ConstantsString.PairRFD8500)
        {
            img1.Source = ImageSource.FromFile(ConstantsString.ImgEmpty);
            img2.Source = ImageSource.FromFile(ConstantsString.ImgEmpty);
        }
        else if (this.Title == ConstantsString.PairLIDS3678)
        {
            img2.Source = ImageSource.FromFile(ConstantsString.Img3678ResetBarcode);
            img3.Source = ImageSource.FromFile(ConstantsString.Img3678SSIBarcode);
        }
        else if (this.Title == ConstantsString.PairRS5100)
        {
            img2.Source = ImageSource.FromFile(ConstantsString.ImgRS5100ResetBarcode);
            img3.Source = ImageSource.FromFile(ConstantsString.ImgRS5100SSIBarcode);
        }
        else if (this.Title == ConstantsString.PairDS2278)
        {
            img2.Source = ImageSource.FromFile(ConstantsString.Img2278Default);
            img3.Source = ImageSource.FromFile(ConstantsString.Img2278SSI);
        }
        else if (this.Title == ConstantsString.SetDefaults)
        {
            img1.Source = ImageSource.FromFile("setdefault.png");

        }
        else if (this.Title == ConstantsString.PairCS6080DS8178MFI)
        {
            img2.Source = ImageSource.FromFile("cs6080ds8178factorydefaults.png");
            img3.Source = ImageSource.FromFile("cs6080ds8178mfissi.png");
        }

        for (int i = 0; i < instructionsList.Count; i++)
        {
            if (i == ConstantsString.Instruction1)
            {
                lb1Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction2)
            {
                lb2Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction3)
            {
                lb3Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction4)
            {
                lb4Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction5)
            {
                lb5Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction6)
            {
                lb6Discription.Text = instructionsList[i];
            }
            else if (i == ConstantsString.Instruction7 && instructionsList.Count <= ConstantsString.Instruction8)
            {
                lb7Discription.Text = instructionsList[i];
            }
            else
            {
                clearAllLableText();
            }
        }

    }






    /// <summary>
    /// clear all label
    /// </summary>
    private void clearAllLableText()
    {
        lb1Discription.Text = ConstantsString.NoInstructions;
        lb2Discription.Text = ConstantsString.NoInstructions;
        lb3Discription.Text = ConstantsString.NoInstructions;
        lb4Discription.Text = ConstantsString.NoInstructions;
        lb5Discription.Text = ConstantsString.NoInstructions;
        lb6Discription.Text = ConstantsString.NoInstructions;
        lb7Discription.Text = ConstantsString.NoInstructions;
    }
}
