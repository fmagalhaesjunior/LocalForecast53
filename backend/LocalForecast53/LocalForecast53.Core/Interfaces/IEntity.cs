namespace LocalForecast53.Core.Interfaces
{
    public interface IEntity<TSourceId>
    {
        TSourceId Id { get; }
    }
}
