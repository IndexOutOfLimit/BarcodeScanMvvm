using SQLite;

namespace BarCodeScanner.Repository.Entities
{
    [Table("BarCodeData")]
    public class BarCodeData : IEntity<int>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BarCodeValue { get; set; }
        public string BarCodeType { get; set; }
        public string BarCodeDescription { get; set; }
    }
}
