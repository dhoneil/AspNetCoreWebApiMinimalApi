using System;
using System.Collections.Generic;

namespace aspnetcorewebapiminimalapi.Models3
{
    public partial class UserInformation
    {
        public ulong UserInformationId { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
