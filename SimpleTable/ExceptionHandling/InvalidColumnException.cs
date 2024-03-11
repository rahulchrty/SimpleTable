namespace SimpleTable.ExceptionHandling
{
    internal class InvalidColumnException : Exception
    {
        internal InvalidColumnException(string message): base(message){}
    }
}
