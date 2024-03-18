namespace Northwind.EntityModels
{
    public interface IHasLastRefresed
    {
        DateTimeOffset LastRefresed { get; set; }
    }
}
