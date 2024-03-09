namespace SimpleTable.Models
{
    public class Column
    {
        public string ColumnName { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
