namespace SimpleTable.ExceptionHandling
{
    internal class InvalidSourceException : Exception
    {
        internal InvalidSourceException()
        : base($"Provided source has no column")
        {
        }

        internal InvalidSourceException(Exception inner)
        : base($"Provided source has no column", inner)
        {
        }
    }
}
