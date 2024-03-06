namespace SimpleTable.ExceptionHandling
{
    internal class InvalidSourceException : Exception
    {
        internal InvalidSourceException()
        : base($"Provided source is invalid")
        {
        }

        internal InvalidSourceException(Exception inner)
        : base($"Provided source is invalid", inner)
        {
        }
    }
}
