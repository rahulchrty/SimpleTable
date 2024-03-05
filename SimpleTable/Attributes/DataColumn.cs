namespace SimpleTable
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataColumn : Attribute
    {
        /// <summary>
        /// Set the table column name.
        /// If not provided then the property name will be set as the column name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Set the column position in the table.
        /// If not provided then the columns will be ordered as the parameter's order.
        /// </summary>
        public int Order { get; set; }
    }
}
