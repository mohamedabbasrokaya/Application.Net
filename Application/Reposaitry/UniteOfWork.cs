using Application.interfaces;

namespace Application.Reposaitry
{

        public class UniteOfWork : IUniteOfWork
    {
        public ICourcesRepo CourcesRepo { get ; set ; }
        public IStudentRepo StudentRepo { get ; set ; }
        public IResultRepo ResultRepo { get ; set ; }
        public UniteOfWork(IStudentRepo studentRepo , ICourcesRepo courcesRepo , IResultRepo resultRepo)
        {
            StudentRepo = studentRepo ;
            CourcesRepo= courcesRepo ;
            ResultRepo= resultRepo ;


        }
    }
}
