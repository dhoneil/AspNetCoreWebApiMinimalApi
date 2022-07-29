using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models3
{
    public partial class BeauticianService
    {
        public ulong BeauticianServiceId { get; set; }
        public int BeauticianId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
