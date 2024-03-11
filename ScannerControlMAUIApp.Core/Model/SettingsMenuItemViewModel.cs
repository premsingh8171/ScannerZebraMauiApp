using ScannerControlMAUIApp.Core.API;
using System.Collections.ObjectModel;

namespace ScannerControlMAUIApp.Core.Model
{
    /// <summary>
    /// SettingsMenuItemViewModel
    /// </summary>
    public class SettingsMenuItemViewModel
    {

        public ObservableCollection<MenuItemModel> SettingsList { get; set; }

        public SettingsMenuItemViewModel()
        {
            SettingsList = new ObservableCollection<MenuItemModel>();
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.Symbologies });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.Beeper });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.EnableScanning });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.DisableScanning });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.AimOn });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.AimOff });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.VibrationFeedback });
            SettingsList.Add(new MenuItemModel { Name = ConstantsString.FirmwareUpdate });

        }
    }
}
