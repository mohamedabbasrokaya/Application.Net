
using Application.Models;

namespace Application.interfaces
{
    public interface ICourcesRepo:IGenericRepo<Cource>
    {
       IEnumerable<Cource> GetCourcetByResult(string Name);
        
    }
}
