namespace BlackoutMonitorAPI.Exceptions
{
    public class UserNotAuthenticatedException : Exception
    {
        public UserNotAuthenticatedException()
            : base("Usuário não identificado no token.")
        {
        }
    }
}
