using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Photo
{
    public class Photo
    {
        [Key]
        public int Id { get; set; } 
        public string Url { get; set; } 
        public int IsMain { get; set; } 
        public int PublicId { get; set; }

     }

}
