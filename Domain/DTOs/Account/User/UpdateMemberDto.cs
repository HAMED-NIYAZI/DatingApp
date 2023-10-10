using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Account.User
{
    public class UpdateMemberDto
    {
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? Intrests { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
