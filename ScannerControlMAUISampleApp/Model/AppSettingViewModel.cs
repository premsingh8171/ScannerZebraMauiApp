using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScannerControlMAUISampleApp.Model
{
    /// <summary>
    /// App Setting View Model
    /// </summary>
    public class AppSettingViewModel : ObservableCollection<AppSettingModel>
    {
        public string Name { get; private set; }

        /// <summary>
        /// set App Setting View Model 
        /// </summary>
        /// <param name="name">Name</param>
        public AppSettingViewModel(string name)
            : base()
        {
            Name = name;
        }

        /// <summary>
        ///  set App Setting View Model 
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="source">Source</param>
        public AppSettingViewModel(string name, IEnumerable<AppSettingModel> source)
            : base(source)
        {
            Name = name;
        }
    }
}
