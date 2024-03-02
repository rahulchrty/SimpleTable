namespace SimpleTable
{
    public static class Position
    {
        public static IAlignment Left { get => new Alignment("left"); }
        public static IAlignment Right { get => new Alignment("right"); }
    }
    public interface IAlignment
    {
        string Style { get; }
        IAlignment Px(double px);
        IAlignment Em(double em);
        IAlignment Rem(double rem);
        IAlignment Ch(double ch);
    }
    public class Alignment : IAlignment
    {
        private string _position { get; set; } = string.Empty;
        public string Style { get; private set; } = string.Empty;
        public Alignment(string position)
        {
            _position = position;
        }
        public IAlignment Px(double px)
        {
            Style = $"{_position}: {px}px";
            return this;
        }
        public IAlignment Em(double em)
        {
            Style = $"{_position}: {em}px";
            return this;
        }
        public IAlignment Rem(double rem)
        {
            Style = $"{_position}: {rem}px";
            return this;
        }
        public IAlignment Ch(double ch)
        {
            Style = $"{_position}: {ch}px";
            return this;
        }
    }
}
