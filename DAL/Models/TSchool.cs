using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TSchool
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public bool? IsDel { get; set; }

    }
}
