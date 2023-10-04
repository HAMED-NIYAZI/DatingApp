using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Photo;

namespace Domain.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
         [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? UserName { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Password { get; set; }

        [Display(Name = "شماره موبایل")]
        [MaxLength(11, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(50, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? Avatar { get; set; }

        [Display(Name = "ایمیل فعال باشد؟")]
        public bool? IsEmailActive { get; set; }

        [Display(Name = "تاریخ تولد ")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Display(Name = "تاریخ آخرین فعالیت")]
        public DateTime? LastActive { get; set; } = DateTime.Now;

        [Display(Name = "نحوه آشنایی")]
         [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? KnownAs { get; set; }
        [Display(Name = "جنسیت")]
         [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? Gender { get; set; }
        [Display(Name = "نام کاربری")]
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? Intrests { get; set; }

        [Display(Name = "شهر")]
         [MaxLength(200, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? City { get; set; }

        [Display(Name = "کشور")]
         [MaxLength(200, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? Country { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime? RegisterDate { get; set; }


        public ICollection<Photo.Photo>? Photos { get; set; }


    }
}
