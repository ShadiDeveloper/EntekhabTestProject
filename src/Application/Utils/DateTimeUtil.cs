using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class DateTimeUtil
    {
        public static string DateTimeToShamsi(this DateTime date)
        {
            string output = "";
            try
            {
                PersianCalendar pc = new PersianCalendar();
                output = string.Format("{0:0000}/{1:00}/{2:00}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
            }
            catch { }

            return output;
        }

        public static DateTime ShamsiToDateTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();

            if (persianDate.Length != 8)
                return DateTime.Now;

            DateTime dateTime = new DateTime(int.Parse(persianDate.Substring(0, 4)), int.Parse(persianDate.Substring(4, 2)), int.Parse(persianDate.Substring(6, 2)), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.InvariantCulture));
        }
    }
}
