using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class TimePeriod
    {
        public TimePeriod(string selectedYear)
        {
            if (!int.TryParse(selectedYear, out int year))
            {
                // fallback → escolhe um valor default
                year = DateTime.Now.Year;
            }

            Start = new DateTime(year, 1, 1);
            End = new DateTime(year, 12, 31);
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
