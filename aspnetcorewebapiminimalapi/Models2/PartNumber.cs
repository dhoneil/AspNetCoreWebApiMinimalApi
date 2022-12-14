using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models
{
    public partial class PartNumber
    {
        public PartNumber()
        {
            Items = new HashSet<Item>();
        }

        public int PartNumberId { get; set; }
        public string? PartNumberName { get; set; }
        public string? PartNumberSuffix { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
