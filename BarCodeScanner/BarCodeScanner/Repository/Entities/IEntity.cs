namespace BarCodeScanner.Repository.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
