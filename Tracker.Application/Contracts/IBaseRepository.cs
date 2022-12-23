namespace Tracker.Application.Contracts;

public interface IBaseRepository<T>
{
    void Create(T item);
    void Update(T item);
    void Remove(T item);
    void SaveChanges();
}