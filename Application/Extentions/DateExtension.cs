using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public static class DateExtension
    {
        public static int CalculateAge(this DateTime date)
        {
            var today = DateTime.Now;
            var age = today.Year - date.Year;
            if (date.Date > today.AddYears(-1)) age--;
            return age;
        }

    }
}
