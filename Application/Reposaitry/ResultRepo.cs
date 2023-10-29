
using Application.interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Reposaitry
{
    public class ResultRepo:GenericRepo<Result>,IResultRepo
    {
        public Result_student_courcesContext Context { get; }

        public ResultRepo(Result_student_courcesContext context):base(context) {
            Context = context;
        }

        public IEnumerable<Result> GetResultWithStudentsAndCourses()
        {
            return Context.Results.Include(r => r.StudentNoNavigation).Include(r => r.CourceNoNavigation).ToList();
        }
        
      
       
    }

}

