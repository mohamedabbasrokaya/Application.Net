using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public string ResultDegree { get; set; } = null!;
        public int? CourceNo { get; set; }
        public int? StudentNo { get; set; }

        public virtual Cource? CourceNoNavigation { get; set; }
        public virtual Student? StudentNoNavigation { get; set; }
    }
}
