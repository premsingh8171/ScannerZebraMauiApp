using System;
using System.Collections.ObjectModel;
using ScannerControlMAUISampleApp.API;

namespace ScannerControlMAUISampleApp.Model
{
    /// <summary>
    /// Menu Item View Model
    /// </summary>
    public class MenuItemViewModel
    {
        public ObservableCollection<MenuItemModel> MenuList { get; set; }

        public MenuItemViewModel()
        {
            MenuList = new ObservableCollection<MenuItemModel>();
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemAvailableScannerList });
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemConnectHelp });
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemAppSetting});
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemAbout });
        }
    }
}
