using ScannerControlMAUIApp.Core.API;
using System.Collections.ObjectModel;

namespace ScannerControlMAUIApp.Core.Model
{
    /// <summary>
    /// SymbologiesItemViewModel
    /// </summary>
    public class SymbologiesItemViewModel
    {
        public ObservableCollection<MenuItemModel> SymbologiesList { get; set; }


        /// <summary>
        /// Initializes a new instance of SymbologiesItemViewModel
        /// </summary>
        public SymbologiesItemViewModel()
        {
            SymbologiesList = new ObservableCollection<MenuItemModel>();
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.Symbologies });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.Beeper });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.EnableScanning });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.DisableScanning });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.AimOn });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.AimOff });
            SymbologiesList.Add(new MenuItemModel { Name = ConstantsString.VibrationFeedback });
        }
    }
}
