using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds) //must be "weekends" due to naming rules because it`s a single word:)
        {
            var weekendsNumber = dayCount - GetDaysNumberWithoutWeekends(startDate, startDate.AddDays(dayCount)); 

            if (weekEnds == null)
                return startDate.AddDays(dayCount + weekendsNumber);             

            int holidaysCount = 0;

            foreach(var weekend in weekEnds)
            {
                holidaysCount += GetDaysNumberWithoutWeekends(weekend.StartDate, weekend.EndDate); //count these days as holidays
            }

            return startDate.AddDays(dayCount + weekendsNumber + holidaysCount);         
        }

        private int GetDaysNumberWithoutWeekends(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("To cannot be smaller than from.", nameof(endDate));

            if (endDate.Date == startDate.Date)
                return 0;

            int n = 0;
            DateTime nextDate = startDate;
            while (nextDate <= endDate.Date)
            {
                if (nextDate.DayOfWeek != DayOfWeek.Saturday && nextDate.DayOfWeek != DayOfWeek.Sunday)
                    n++;
                nextDate = nextDate.AddDays(1);
            }

            return n;
        }       
    }
}
