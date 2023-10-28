
using Application.interfaces;
using Application.Models;

namespace Application.Reposaitry
{

    public class StudentRepo:GenericRepo<Student>,IStudentRepo
 {
     public StudentRepo(Result_student_courcesContext context):base(context)
     {

     }

     public IEnumerable<Student> GetStudentByResult(string Name)
     {
         throw new NotImplementedException();
     }
 }
}
