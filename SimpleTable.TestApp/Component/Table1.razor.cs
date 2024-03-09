using SimpleTable.TestApp.Model;

namespace SimpleTable.TestApp.Component
{
    public partial class Table1
    {
        private List<DataModel> _data {  get; set; } = new ();
        public Table1()
        {
            for (int i = 0; i < 3; i++)
            {
                _data.Add(new DataModel
                {
                    Id = i + 1,
                    Name = "Foo",
                    Description = "Bar",
                    //MFD = DateTime.Now,
                    //Expiry = DateTime.Now.AddYears(1),
                    Price = 12 + i,
                    //Currency = "Rupee"
                });
            }
        }

    }
}
