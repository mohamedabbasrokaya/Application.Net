
using Application.interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Reposaitry
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
   {
       
       public GenericRepo(Result_student_courcesContext  context)
        {
            Context = context;
        }

       public Result_student_courcesContext Context { get; }
        
        public async Task<int> AddAsync(T item)
        {
           await Context.Set<T>().AddAsync( item);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> Add(T item)
        {
            await Context.Set<T>().AddAsync(item);
            return await Context.SaveChangesAsync();
        }     

        public async Task<int> DeleteAsync(T item)
        {
            Context.Set<T>().Remove( item);
            return await Context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int? id)
        =>await Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
        =>await Context.Set<T>().ToListAsync();

        public async Task<int> UpdateAsync(T item)
        {
           Context.Set<T>().Update(item);
            return await Context.SaveChangesAsync();
        }
    
    }
}
