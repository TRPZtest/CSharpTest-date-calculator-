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
            int workingDays = 0;  
            
            if (weekEnds == null)
                return startDate.AddDays(dayCount -1);
          
            while (workingDays != dayCount)
            {           
                var isHoliday = IsHoliday(startDate, weekEnds);

                if (!isHoliday)
                    workingDays++;

                startDate = startDate.AddDays(1);
            }
            return startDate.AddDays(-1);
        }

        private bool IsHoliday(DateTime date, WeekEnd[] weekEnds)
        {
            return weekEnds.Any(x => x.StartDate <= date && x.EndDate >= date);
        }       
        
       
    }
}
