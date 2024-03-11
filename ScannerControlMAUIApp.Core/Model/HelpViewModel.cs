using ScannerControlMAUIApp.Core.API;
using System.Collections.ObjectModel;

namespace ScannerControlMAUIApp.Core.Model
{
    /// <summary>
    /// Help view model
    /// </summary>
    public class HelpViewModel
    {
        public ObservableCollection<HelpPairModel> BluetoothPairList { get; set; }

        public HelpViewModel()
        {
            BluetoothPairList = new ObservableCollection<HelpPairModel>();
            BluetoothPairList.Add(new HelpPairModel { PairName = ConstantsString.DS8178ListItemBTLE });
            BluetoothPairList.Add(new HelpPairModel { PairName = ConstantsString.DS8178ListItemMFI });

        }
    }
}
