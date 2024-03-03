namespace SimpleTable.TestApp.Model
{
    public class DataModel
    {
        [ColumnConfig(Order = 1)]
        public int Id { get; set; }
        [ColumnConfig(Name ="Product Name", Order = 2)]
        public string Name { get; set; } = string.Empty;
        [ColumnConfig(Order = 3)]
        public string Description { get; set; } = string.Empty;
        [ColumnConfig(Order = 4)]
        public double Price { get; set; }
        [ColumnConfig(Name= "Manufacturing Date", Order = 6)]
        public DateTime MFD { get; set; }
        [ColumnConfig(Name = "Expiry Date", Order = 7)]
        public DateTime Expiry { get; set; }
        [ColumnConfig(Order = 5)]
        public string Currency { get; set; } = string.Empty;
    }
}
