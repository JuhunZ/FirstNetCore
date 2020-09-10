using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TUser
    {
        public int UseId { get; set; }
        public string UserName { get; set; }
        public int? Age { get; set; }
        public string Qq { get; set; }
        public string Address { get; set; }
        public int? SchoolId { get; set; }
        public string ParentName { get; set; }
        public bool? IsDel { get; set; }

    }
}
