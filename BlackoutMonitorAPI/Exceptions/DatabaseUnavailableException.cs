namespace BlackoutMonitorAPI.Exceptions
{
    public class DatabaseUnavailableException : Exception
    {
        public DatabaseUnavailableException(string message)
            : base(message)
        {
        }
    }
}
