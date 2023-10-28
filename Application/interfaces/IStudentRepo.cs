
using Application.Models;

namespace Application.interfaces
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
      IEnumerable<Student> GetStudentByResult(string Name);

    }
}
