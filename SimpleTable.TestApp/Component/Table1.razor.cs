using SimpleTable.Models;
using SimpleTable.TestApp.Model;

namespace SimpleTable.TestApp.Component
{
    public partial class Table1
    {
        private List<DataModel> _data { get; set; } = new();
        private List<Column> _localization;
        public Table1()
        {
            ConstructData();
            _localization = ConstructLocalizationData();
        }

        private List<Column> ConstructLocalizationData()
        {
            List<Column> localization = new()
            {
                { new Column{ PropertyName = "LastName", Order=2} },
                { new Column{ PropertyName = "Phone", ColumnName="Mobile", Order=6} }
            };
            return localization;
        }

        private void ConstructData()
        {
            for (int i = 0; i < 20; i++)
            {
                _data.Add(new DataModel
                {
                    Id = i + 1,
                    FirstName = $"Foo{i}",
                    MiddleName = string.Empty,
                    LastName = $"Bar{i}",
                    CurrentAddress = "Current Address",
                    PermanentAddress = "Permanent Address",
                    Dob = DateTime.Now.AddYears(-44).ToString("dd/MM/yyyy"),
                    Phone = $"000-000-00{i + 1}",
                });
            }
        }

    }
}
