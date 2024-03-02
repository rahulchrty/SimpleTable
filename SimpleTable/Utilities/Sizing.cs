using SimpleTable.Models;

namespace SimpleTable
{
    public static class Size
    {
        public static ISizing Px { get; private set; } = new Sizing("px");
        public static ISizing Em { get; private set; } = new Sizing("em");
        public static ISizing Rem { get; private set; } = new Sizing("rem");
        public static ISizing Ch { get; private set; } = new Sizing("ch");
    }

    public interface ISizing
    {
        WidthAndHeight Measurement { get; }
        ISizing Height(double height);
        ISizing Width(double height);
    }

    public class Sizing : ISizing
    {
        public WidthAndHeight Measurement { get; private set; } = new();
        public Sizing(string unit)
        {
            Measurement.Unit = unit;
        }
        public ISizing Height(double height)
        {
            Measurement.Height = height;
            return this;
        }
        public ISizing Width(double width)
        {
            Measurement.Width = width;
            return this;
        }
    }
}
