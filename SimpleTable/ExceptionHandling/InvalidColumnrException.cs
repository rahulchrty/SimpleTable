namespace SimpleTable.ExceptionHandling
{
    internal class InvalidColumnrException : Exception
    {
        internal InvalidColumnrException(string message): base(message){}
    }
}
