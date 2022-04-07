using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public class StatisticsTask
    {
        //IEnumerable<double>
        public static double GetMedianTimePerSlide(List<VisitRecord> visits, SlideType slideType)
        {
            var resultVisitList = GetVisitRecord(visits, slideType);
            if (resultVisitList.Count() == 0)
                return 0;

            return resultVisitList.Median();
        }

        private static IEnumerable<double> GetVisitRecord(List<VisitRecord> visits, SlideType slideType)
        {
            var visitlist = from visit in visits
                            orderby visit.UserId
                            orderby visit.DateTime
                            group visit by visit.UserId;

            var resultVisitList = visitlist
            .SelectMany(visitsGroup => visitsGroup.Bigrams()
                .Where(visit => visit.Item1.SlideType == slideType))
            .Select(items => (items.Item2.DateTime - items.Item1.DateTime).TotalMinutes)
                .Where(GetTime());
            return resultVisitList;
        }

        private static Func<double, bool> GetTime()
        {
            return minutes => minutes >= 1 && minutes <= 120;
        }
    }
}