namespace Application.interfaces
{
   public interface IUniteOfWork
    {
        public ICourcesRepo CourcesRepo { get; set; }
        public IStudentRepo StudentRepo { get; set; }
        public IResultRepo ResultRepo { get; set; }

    }
}
