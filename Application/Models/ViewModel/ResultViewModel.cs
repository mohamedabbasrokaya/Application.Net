namespace Application.Models.ViewModel
{
    public class ResultViewModel
    {
        public int ResultId { get; set; }
        public string ResultDegree { get; set; } = null!;
        public int? StudentNo { get; set; }
        public int? CourceNo { get; set; } 

        public StudentViewModel? student { get; set;}
       public CourcesViewModel? Cources { get; set; }

   
    }
}
