
using Application.interfaces;
using Application.Models;

namespace Application.Reposaitry
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
   {
       
       public GenericRepo(Result_student_courcesContext context)
        {
            Context = context;
        }

       public Result_student_courcesContext Context { get; }
        
        public int Add(T item)
        {
            Context.Set<T>().Add( item);
            return Context.SaveChanges();
        }

        public int Delete(T item)
        {
           Context.Set<T>().Remove( item);
            return Context.SaveChanges();
        }

        public T Get(int? id)
        => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
        =>Context.Set<T>().ToList();

        public int Update(T item)
        {
            Context.Set<T>().Update(item);
            return Context.SaveChanges();
        }
    
    }
}
