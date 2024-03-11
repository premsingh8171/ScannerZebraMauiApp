using System;
using System.Collections.ObjectModel;
using ScannerControlMAUISampleApp.API;

namespace ScannerControlMAUISampleApp.Model
{
    /// <summary>
    /// Help PairView Model
    /// </summary>
    public class HelpPairViewModel
    {
        public ObservableCollection<HelpPairModel> PairList { get; set; }

      
        public HelpPairViewModel()
        {
            PairList = new ObservableCollection<HelpPairModel>();
         
#if __ANDROID__
            HelpMenuItemsTypeTwo();
#endif
#if __IOS__
             HelpMenuItemsTypeOne();
#endif

        }

        /// <summary>
        /// Help Menu Items Type One
        /// </summary>
        void HelpMenuItemsTypeOne()
        {
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairCS4070 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairRFD8500 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairLIDS3678 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairDS8178CS6080 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairDS2278 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairRS5100 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.SetDefaults });

        }

        /// <summary>
        /// Help MenuItems Type Two
        /// </summary>
        void HelpMenuItemsTypeTwo()
        {
         
            PairList.Add(new HelpPairModel { PairName = ConstantsString.PairRFD8500 });
            PairList.Add(new HelpPairModel { PairName = ConstantsString.SetDefaults });

        }
    }
}
