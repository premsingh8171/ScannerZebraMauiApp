namespace ScannerControlMAUIApp.Core.Model
{
    /// <summary>
    /// BarcodeModel
    /// </summary>
    public class BarcodeModel
    {
        public byte[] BarcodeData { get; set; }
        public string DecodeData { get; set; }
        public string BarcodeType { get; set; }
        public int ScannerID { get; set; }

    }
}
