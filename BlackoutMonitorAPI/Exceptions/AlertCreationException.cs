namespace BlackoutMonitorAPI.Exceptions
{
    public class AlertCreationException : Exception
    {
        public AlertCreationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
