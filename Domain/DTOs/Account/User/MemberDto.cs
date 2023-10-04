using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DTOs.Account.User
{
    public class MemberDto
    {
        #region prop
        [Key]
        public int Id { get; set; }
 
        public string Email { get; set; }
 
        public string? UserName { get; set; }
 
        public string? Mobile { get; set; }

         public string? Avatar { get; set; }

         public bool? IsEmailActive { get; set; }

         public int? age { get; set; }  

  
        public string? KnownAs { get; set; }
 
        public string? Gender { get; set; }
         public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? Intrests { get; set; }
 
        public string? City { get; set; }
 
        public string? Country { get; set; }

         public DateTime? RegisterDate { get; set; }

        public  ICollection<Photo.PhotoDto>? Photos { get; set; }
        #endregion
    }
}
