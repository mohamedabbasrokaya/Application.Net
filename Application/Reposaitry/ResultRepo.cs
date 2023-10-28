
using Application.interfaces;
using Application.Models;

namespace Application.Reposaitry
{
    public class ResultRepo:GenericRepo<Result>,IResultRepo
    {
        public ResultRepo(Result_student_courcesContext context):base(context) { 
        
        }
        
    }
}
