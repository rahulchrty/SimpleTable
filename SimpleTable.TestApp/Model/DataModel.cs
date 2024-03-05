namespace SimpleTable.TestApp.Model
{
    public class DataModel
    {
        //[DataColumn(Order = 1)]
        //public int Id { get; set; }
        //[DataColumn(Name ="Product Name", Order = 2)]
        //public string Name { get; set; } = string.Empty;
        //[DataColumn(Order = 3)]
        //public string Description { get; set; } = string.Empty;
        //[DataColumn(Order = 4)]
        //public double Price { get; set; }
        //[DataColumn(Name= "Manufacturing Date", Order = 6)]
        //public DateTime MFD { get; set; }
        //[DataColumn(Name = "Expiry Date", Order = 7)]
        //public DateTime Expiry { get; set; }
        //[DataColumn(Order = 5)]
        //public string Currency { get; set; } = string.Empty;
        //[DataColumn(Order = 5)]
        //public string MD { get; set; } = string.Empty;

        //[DataColumn(Order = 1)]
        public int Id { get; set; }

        //[DataColumn(Name = "Product Name", Order = 2)]
        public string Name { get; set; } = string.Empty;

        //[DataColumn(Order = 3)]
        public string Description { get; set; } = string.Empty;

        //[DataColumn(Order = 3)]
        public double Price { get; set; }
    }
}
