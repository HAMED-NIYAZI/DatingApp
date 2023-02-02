using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید.")]
        [MaxLength(350,ErrorMessage ="حداکثر کاراکتر مجاز {1} می باشد")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string UserName { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Password { get; set; }
    }
}
