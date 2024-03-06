using SimpleTable;

namespace TesterConsole.Models
{
    public class SourceData1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
    }

    public class SourceData2
    {
        [ColumnConfig]
        public int Id { get; set; }
        [ColumnConfig]
        public string FirstName { get; set; }
        [ColumnConfig]
        public string LastName { get; set; }
        [ColumnConfig]
        public string DateOfBirth { get; set; }
        [ColumnConfig]
        public string Address { get; set; }
    }

    public class SourceData3
    {
        [ColumnConfig(Name = "Id")]
        public int Id { get; set; }
        [ColumnConfig(Name = "First Name")]
        public string FirstName { get; set; }
        [ColumnConfig(Name = "Last Name")]
        public string LastName { get; set; }
        [ColumnConfig(Name = "Date of birth")]
        public string DateOfBirth { get; set; }
        [ColumnConfig(Name = "Address")]
        public string Address { get; set; }
    }

    public class SourceData4
    {
        [ColumnConfig(Name = "Id")]
        public int Id { get; set; }
        [ColumnConfig(Name = "First Name")]
        public string FirstName { get; set; }
        [ColumnConfig(Name = "Last Name")]
        public string LastName { get; set; }
        [ColumnConfig(Name = "Date of birth")]
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
    }

    public class SourceData5
    {
        [ColumnConfig(Name = "Id", Order = 1)]
        public int Id { get; set; }
        [ColumnConfig(Name = "First Name", Order = 2)]
        public string FirstName { get; set; }
        [ColumnConfig(Name = "Last Name", Order = 3)]
        public string LastName { get; set; }
        [ColumnConfig(Name = "Date of birth", Order = 4)]
        public string DateOfBirth { get; set; }
        [ColumnConfig(Name = "Address", Order = 5)]
        public string Address { get; set; }
    }

    public class SourceData6
    {
        [ColumnConfig(Name = "Id", Order = 1)]
        public int Id { get; set; }

        public string SomethingElse { get; set; }

        [ColumnConfig(Order = 3)]
        public string Prefix { get; set; }

        [ColumnConfig(Name = "First Name", Order = 4)]
        public string FirstName { get; set; }

        [ColumnConfig(Name = "Last Name", Order = 2)]
        public string LastName { get; set; }

        [ColumnConfig(Order = 5)]
        public string Sufix { get; set; }

        [ColumnConfig(Name = "Date of birth", Order = 8)]
        public string DateOfBirth { get; set; }

        [ColumnConfig(Name = "Phone number")]
        public string Phone { get; set; }

        [ColumnConfig(Name = "Current Address")]
        public string Address { get; set; }

        [ColumnConfig(Name = "Department", Order = 7)]
        public string Department { get; set; }
    }
}
