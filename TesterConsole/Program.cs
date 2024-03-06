using SimpleTable.Models;
using SimpleTable.TableConfig;
using TesterConsole.Models;

#region DATA
List<SourceData1> sourceData1s = new();
for (int i = 0; i < 10; i++)
{
    sourceData1s.Add(new SourceData1
    {
        Id = i,
        FirstName = $"First Name {i}",
        LastName = $"Last Name {i}",
        DateOfBirth = DateTime.Now.AddYears(40).AddYears(-i).ToString("dd/MM/yyyy")
    });
}
#endregion DATA

#region List<string> GetProperties(TSource source)
void GetProperties_Test1()
{
    ColumnSetting<SourceData1> cc = new();
    var props = cc.GetPropertiesByPropertyOrder(sourceData1s[0]);
    Console.WriteLine($"GetProperties_Test1: {props.Count}");
}
//GetProperties_Test1();
void GetProperties_Test2()
{
    try
    {
        ColumnSetting<EmptySource> cc = new();
        var props = cc.GetPropertiesByPropertyOrder(new EmptySource());
        Console.WriteLine($"GetProperties_Test1: {props.Count}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
//GetProperties_Test2();
#endregion List<string> GetProperties(TSource source)

#region List<Column> GetColumnAttributeDetails(List<string> properties)
void GetColumnAttributeDetails_Test1()
{
    ColumnSetting<SourceData1> cc = new();
    List<string> props = ["Id", "FirstName", "LastName", "DateOfBirth", "Address"];
    var data = cc.GetColumnAttributeDetailsByPropertyName(props);
    Console.WriteLine(data.Count);
}
//GetColumnAttributeDetails_Test1();
void GetColumnAttributeDetails_Test2()
{
    ColumnSetting<SourceData2> cc = new();
    List<string> props = ["Id", "FirstName", "LastName", "DateOfBirth", "Address"];
    var data = cc.GetColumnAttributeDetailsByPropertyName(props);
    Console.WriteLine(data.Count);
}
//GetColumnAttributeDetails_Test2();

void GetColumnAttributeDetails_Test3()
{
    ColumnSetting<SourceData3> cc = new();
    List<string> props = ["Id", "FirstName", "LastName", "DateOfBirth", "Address"];
    var data = cc.GetColumnAttributeDetailsByPropertyName(props);
    Console.WriteLine(data.Count);
}
//GetColumnAttributeDetails_Test3();

void GetColumnAttributeDetails_Test4()
{
    ColumnSetting<SourceData4> cc = new();
    List<string> props = ["Id", "FirstName", "LastName", "DateOfBirth", "Address"];
    var data = cc.GetColumnAttributeDetailsByPropertyName(props);
    Console.WriteLine(data.Count);
}
//GetColumnAttributeDetails_Test4();

void GetColumnAttributeDetails_Test5()
{
    ColumnSetting<SourceData5> cc = new();
    List<string> props = ["Id", "FirstName", "LastName", "DateOfBirth", "Address"];
    var data = cc.GetColumnAttributeDetailsByPropertyName(props);
    Console.WriteLine(data.Count);
}
//GetColumnAttributeDetails_Test5();
#endregion List<Column> GetColumnAttributeDetails(List<string> properties)

#region bool HasDuplicateColumn(List<Column> colDetails)
void HasDuplicateColumn_Test1()
{
    List<Column> colDetails =
    [
        new Column {
            Order = 1,
        },
                new Column {
            Order = 2,
        },
                new Column {
            Order = 3,
        },
                new Column {
            Order = 4,
        },
    ];
    ColumnSetting<SourceData5> cc = new();
    bool isValid = cc.HasDuplicateColumn(colDetails);
    Console.WriteLine(isValid);
}
//HasDuplicateColumn_Test1();
void HasDuplicateColumn_Test2()
{
    List<Column> colDetails =
    [
        new Column {
            Order = 1,
        },
                new Column {
            Order = 2,
        },
                new Column {
            Order = 2,
        },
                new Column {
            Order = 4,
        },
    ];
    ColumnSetting<SourceData5> cc = new();
    bool isValid = cc.HasDuplicateColumn(colDetails);
    Console.WriteLine(isValid);
}
//HasDuplicateColumn_Test2();
#endregion bool HasDuplicateColumn(List<Column> colDetails)

#region List<Column> OrderColumns(List<string> properties, List<Column> colDetails)
void OrderColumns_Test1()
{
    Dictionary<int, string> props = new()
    {
        { 1, "Id" },
        { 2, "Sufix" },
        { 3, "FirstName" },
        { 4, "LastName" },
        { 5, "DateOfBirth" },
        { 6, "Phone" },
        { 7, "Address" }
    };

    List<Column> colDetails =
    [
    new Column {
            Order = 1,
            PropertyName = "Id",
            ColumnName = "Id"
        },
                new Column {
            Order = 2,
            PropertyName = "FirstName",
            ColumnName = "First Name"
        },
                new Column {
            Order = 0,
            PropertyName = "LastName",
            ColumnName = "Last Name"
        },
                new Column {
            Order = 7,
            PropertyName = "DateOfBirth",
            ColumnName = "Date of birth"
        },
                new Column {
            Order = 0,
            PropertyName = "Address",
            ColumnName = "Address"
        },
    ];
    ColumnSetting<SourceData5> cc = new();
    var cols = cc.OrderColumns(props, colDetails);
    Console.WriteLine();
}
//OrderColumns_Test1();
#endregion List<Column> OrderColumns(List<string> properties, List<Column> colDetails)

#region List<Column> GetColumn(TSource source)
void GetColumn_Test1()
{
    ColumnSetting<SourceData1> colSetting = new();
    var cols = colSetting.GetColumns(new SourceData1());
    Console.WriteLine();
}
//GetColumn_Test1();
void GetColumn_Test2()
{
    ColumnSetting<SourceData2> colSetting = new();
    var cols = colSetting.GetColumns(new SourceData2());
    Console.WriteLine();
}
//GetColumn_Test2();
void GetColumn_Test3()
{
    ColumnSetting<SourceData3> colSetting = new();
    var cols = colSetting.GetColumns(new SourceData3());
    Console.WriteLine();
}
//GetColumn_Test3();
void GetColumn_Test5()
{
    ColumnSetting<SourceData5> colSetting = new();
    var cols = colSetting.GetColumns(new SourceData5());
    Console.WriteLine();
}
//GetColumn_Test5();

void GetColumn_Test6()
{
    ColumnSetting<SourceData6> colSetting = new();
    var cols = colSetting.GetColumns(new SourceData6());
    Console.WriteLine();
}
//GetColumn_Test6();
#endregion List<Column> GetColumn(TSource source)