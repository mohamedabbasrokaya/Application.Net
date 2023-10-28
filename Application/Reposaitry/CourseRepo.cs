
using Application.interfaces;
using Application.Models;

namespace Application.Reposaitry
{

    public class CourseRepo:GenericRepo<Cource>,ICourcesRepo
    {
        public CourseRepo(Result_student_courcesContext context) :base(context)
        {
                
        }

        public IEnumerable<Cource> GetCourcetByResult(string Name)
        {
            throw new NotImplementedException();
       }
    }
}
