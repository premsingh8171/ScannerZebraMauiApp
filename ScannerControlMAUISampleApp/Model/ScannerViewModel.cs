using System;
using System.Collections.ObjectModel;
using ScannerControlMAUISampleApp.Model;
using ScannerControlMAUISampleApp.API;

namespace ScannerControlMAUISampleApp.Model
{
    /// <summary>
    /// This tempory class to see the ui with sample reader.
    /// will remove after api integration
    /// </summary>
    public class ScannerViewModel
    {
        public ObservableCollection<MenuItemModel> ScannerList { get; set; }

        public ScannerViewModel()
        {
            ScannerList = new ObservableCollection<MenuItemModel>();
            ScannerList.Add(new MenuItemModel { Name = ConstantsString.SampleScanner1 });
            ScannerList.Add(new MenuItemModel { Name = ConstantsString.SampleScanner2 });

        }
    }
}
