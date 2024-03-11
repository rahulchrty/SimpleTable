namespace SimpleTable.TestApp.Model
{
    public class DataModel
    {
        [ColumnConfig(Order = 1)]
        public int Id { get; set; }

        [ColumnConfig(Name = "First Name", Order = 2)]
        public string FirstName { get; set; } = string.Empty;

        [ColumnConfig(Name = "Middle Name", Order = 3)]
        public string MiddleName { get; set; } = string.Empty;

        [ColumnConfig(Name = "Last Name", Order = 4)]
        public string LastName { get; set; } = string.Empty;

        [ColumnConfig(Name="Date of birth", Order = 5)]
        public string Dob { get; set; } = string.Empty;

        [ColumnConfig(Name="Current Address", Order = 6)]
        public string CurrentAddress { get; set; }

        [ColumnConfig(Name = "Permanent Address", Order = 7)]
        public string PermanentAddress { get; set; }

        [ColumnConfig(Name = "Phone Number", Order = 8)]
        public string Phone { get; set; }
    }
}
