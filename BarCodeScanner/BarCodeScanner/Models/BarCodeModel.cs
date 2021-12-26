namespace BarCodeScanner.Models
{
    public class BarCodeModel
    {
        public int Id { get; set; }
        public string BarCodeValue { get; set; }
        public string BarCodeType { get; set; }
        public string BarCodeDescription { get; set; }

        public bool IsSelected { get; set; }
    }
}
