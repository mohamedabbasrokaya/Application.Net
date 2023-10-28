namespace Application.interfaces
{
    public interface IGenericRepo<T>
    {
        Task<T> GetAsync(int? id);

       // T Get(int? id);
       Task<IEnumerable<T>> GetAllAsync();

       // IEnumerable<T> GetAll();
        Task<int> AddAsync(T item);
        //int Add(T item);
        Task<int> UpdateAsync(T item);

         //  int Update(T item);
        Task<int> DeleteAsync(T item);

       // int Delete(T item);


    }
}
