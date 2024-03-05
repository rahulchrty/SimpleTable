namespace SimpleTable.ExceptionHandling
{
    internal class InvalidColumnOrderException : Exception
    {
        internal InvalidColumnOrderException(int orderNumber)
            : base($"Invalid column order. Column order {orderNumber} is provided more than once.")
        {
        }

        internal InvalidColumnOrderException(int orderNumber, Exception inner)
            : base($"Invalid column order. Column order {orderNumber} is provided more than once.", inner)
        {
        }
    }
}
