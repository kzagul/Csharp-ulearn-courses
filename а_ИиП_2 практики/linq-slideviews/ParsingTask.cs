
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace linq_slideviews
{
	public class ParsingTask
	{
        public static int dataStructLength = 3;
        public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
        {
            return lines
                .Select(line =>
                {
                    string[] parameters = Constructor(line);
                    string firstParameter = parameters[1];
                    if (parameters.Length < dataStructLength ||
                        !int.TryParse(parameters[0], out int slide))
                        return null;
                    if (firstParameter == "quiz")
                        return new SlideRecord(slide, SlideType.Quiz, parameters[2]);
                    if (firstParameter == "theory")
                        return new SlideRecord(slide, SlideType.Theory, parameters[2]);
                    if (firstParameter == "exercise")
                        return new SlideRecord(slide, SlideType.Exercise, parameters[2]);
                    else
                        return null;
                })
                .Where(slideRecord => slideRecord != null)
                .ToDictionary(slideRecord => slideRecord.SlideId);
        }
        private static SlideRecord Parsing(string line)
        {
            string[] parameters = Constructor(line);
            string firstParameter = parameters[1];
            if (parameters.Length < dataStructLength ||
                !int.TryParse(parameters[0], out int slide))
                return null;
            if (firstParameter == "quiz")
                return new SlideRecord(slide, SlideType.Quiz, parameters[2]);
            if (firstParameter == "theory")
                return new SlideRecord(slide, SlideType.Theory, parameters[2]);
            if (firstParameter == "exercise")
                return new SlideRecord(slide, SlideType.Exercise, parameters[2]);
            else
                return null;
        }

        public static IEnumerable<VisitRecord> ParseVisitRecords(
            IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
        {
            return lines
                .Skip(1)
                .Select(line =>
            {
                string[] lineParams = Constructor(line);
                if (lineParams.Length < dataStructLength 
                    || !int.TryParse(lineParams[0], out int userID) 
                    || !int.TryParse(lineParams[1], out int slideID) 
                    || !slides.TryGetValue(slideID, out SlideRecord slideRecord) 
                    || !DateTime.TryParseExact(lineParams[2], "yyyy-MM-dd;HH:mm:ss",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime)) 
                    
                    throw new FormatException($"Wrong line [{line}]");
                    
                return new VisitRecord(userID, slideID, dateTime, slideRecord.SlideType);
            });
        }
        public static string[] Constructor(string line)
        {
            return line.Split(new[] { ';' }, dataStructLength, StringSplitOptions.RemoveEmptyEntries);
        }


        //public static int dataStructLength = 3;
        //public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
        //{
        //    return lines
        //            .Skip(1)
        //            .Select(line => { return ParseLines(line); })
        //            .Where(slide => slide != null).ToDictionary(slide => slide.SlideId);
        //}
        //private static SlideRecord ParseLines(string line)
        //{
        //    string[] paremeters = Constructor(line);
        //    string firstParameter = paremeters[1];
        //    if (paremeters.Length < dataStructLength ||
        //        !int.TryParse(paremeters[0], out int slide))
        //        return null;
        //    else if (firstParameter == "quiz")
        //        return new SlideRecord(slide, SlideType.Quiz, paremeters[2]);
        //    else if (firstParameter == "theory")
        //        return new SlideRecord(slide, SlideType.Theory, paremeters[2]);
        //    else if (firstParameter == "exercise")
        //        return new SlideRecord(slide, SlideType.Exercise, paremeters[2]);
        //    else
        //        return null;
        //}
        //public static IEnumerable<VisitRecord> ParseVisitRecords(
        //    IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
        //{
        //    return lines
        //            .Skip(1)
        //            .Select(line =>
        //            {
        //                string[] linesParemeters = Constructor(line);
        //                if (linesParemeters.Length < dataStructLength
        //                    || !int.TryParse(linesParemeters[0], out int user)
        //                    || !int.TryParse(linesParemeters[1], out int slide)
        //                    || !slides.TryGetValue(slide, out SlideRecord slideRecord)
        //                    || !DateTime.TryParseExact(linesParemeters[2], "yyyy-MM-dd;HH:mm:ss",
        //                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        //                    throw new FormatException($"Wrong line [{line}]");

        //                return new VisitRecord(user, slide, date, slideRecord.SlideType);
        //            });
        //}
        //public static string[] Constructor(string line)
        //{
        //    return line.Split(new[] { ';' }, 3, StringSplitOptions.RemoveEmptyEntries);
        //}
    }
}