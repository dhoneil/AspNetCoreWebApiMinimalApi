using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models3
{
    public partial class Customer
    {
        public ulong CustomerId { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Lastname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
