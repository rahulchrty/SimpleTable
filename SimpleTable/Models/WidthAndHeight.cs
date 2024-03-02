namespace SimpleTable.Models
{
    public record WidthAndHeight
    {
        internal double? Height { get; set; }
        internal double? Width { get; set; }
        internal string Unit { get; set; } = string.Empty;
    }
}
