using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models3
{
    public partial class Appointment
    {
        public ulong AppointmentId { get; set; }
        public int? CustomerId { get; set; }
        public int BeauticianId { get; set; }
        public int ServiceId { get; set; }
        public int ProductId { get; set; }
        public DateTime Schedule { get; set; }
        public decimal TotalAmount { get; set; }
        public string AppointmentStatus { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
