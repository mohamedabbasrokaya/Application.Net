namespace Application.interfaces
{
    public interface IGenericRepo<T>
    {
        T Get(int? id);
        IEnumerable<T> GetAll();
        int Add(T item);
        int Update(T item);
        int Delete(T item);


    }
}
