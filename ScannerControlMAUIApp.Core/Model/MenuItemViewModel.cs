using ScannerControlMAUIApp.Core.API;
using System.Collections.ObjectModel;

namespace ScannerControlMAUIApp.Core.Model
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
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemAppSetting });
            MenuList.Add(new MenuItemModel { Name = ConstantsString.MainListItemAbout });
        }
    }
}
