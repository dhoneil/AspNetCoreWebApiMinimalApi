using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public bool? IsActive { get; set; }
    }
}
