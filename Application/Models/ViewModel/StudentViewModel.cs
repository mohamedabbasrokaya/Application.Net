using System.ComponentModel.DataAnnotations;

namespace Application.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Name Is Requird")]
        public string StudentName { get; set; } = null!;
        // [RegularExpression("[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}")]
        [Required(ErrorMessage = "Adress Is Requird")]
        public string StudentAdress { get; set; } = null!;
        public string? Phone { get; set; }
       

    }
}
