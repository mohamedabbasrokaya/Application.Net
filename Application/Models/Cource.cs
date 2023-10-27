using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Cource
    {
        public Cource()
        {
            Results = new HashSet<Result>();
        }

        public int CourcesId { get; set; }
        public string CourcesName { get; set; } = null!;
        public string Code { get; set; } = null!;

        public virtual ICollection<Result> Results { get; set; }
    }
}
