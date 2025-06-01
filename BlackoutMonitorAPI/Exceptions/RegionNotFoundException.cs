namespace BlackoutMonitorAPI.Exceptions
{
    public class RegionNotFoundException : Exception
    {
        public RegionNotFoundException(int regionId) : base($"Região com ID {regionId} não foi encontrada.")
        {
        }
    }
}
