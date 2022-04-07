using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Reports
{
	public class Style
	{
		public string BeginList { get; private set; }
        public string EndList { get; private set; }
        public Func<string, string> MakeCaption;
		public Func<string, string, string> MakeItem;
		public Style(string beginList, string endList,
			Func<string, string> makeCaption, Func<string, string, string> makeItem)
		{
			BeginList = beginList;
			EndList = endList;
			MakeCaption = makeCaption;
			MakeItem = makeItem;
		}
	}

	public class Calculus<T>
	{
		public string Caption { get; private set; }
		public Func<IEnumerable<double>, T> MakeStatistics;
		public Calculus(string caption, Func<IEnumerable<double>, T> makeStatistics)
		{
			Caption = caption;
			MakeStatistics = makeStatistics;
		}
	}

    public static class ReportMakerHelper
    {
        public static string MakeReport<T>(IEnumerable<Measurement> measurements,
            Style style, Calculus<T> calculus)
        {
            var data = measurements.ToList();
            var result = new StringBuilder();
            result.Append(style.MakeCaption(calculus.Caption));
            result.Append(style.BeginList);
            result.Append(style.MakeItem("Temperature",
                calculus.MakeStatistics(data.Select(z => z.Temperature)).ToString()));
            result.Append(style.MakeItem("Humidity",
                calculus.MakeStatistics(data.Select(z => z.Humidity)).ToString()));
            result.Append(style.EndList);
            return result.ToString();
        }

        

        public static string MeanAndStdHtmlReport(IEnumerable<Measurement> measurements)
        {
            return MakeReport(measurements, Report.htmlStyle, Report.mas);
        }

        public static string MedianMarkdownReport(IEnumerable<Measurement> measurements)
        {
            return MakeReport(measurements, Report.markdownStyle, Report.median);
        }

        public static string MeanAndStdMarkdownReport(IEnumerable<Measurement> measurements)
        {
            return MakeReport(measurements, Report.markdownStyle, Report.mas);
        }

        public static string MedianHtmlReport(IEnumerable<Measurement> measurements)
        {
            return MakeReport(measurements, Report.htmlStyle, Report.median);
        }
    }

    public static class Report
    {
        public static Style htmlStyle = new Style("<ul>", "</ul>",
                caption => $"<h1>{caption}</h1>",
                (valueType, entry) => $"<li><b>{valueType}</b>: {entry}");

        public static Style markdownStyle = new Style("", "",
                caption => $"## {caption}\n\n",
                (valueType, entry) => $" * **{valueType}**: {entry}\n\n");

        public static Calculus<double> median = new Calculus<double>("Median", MedianCalculate());

        private static Func<IEnumerable<double>, double> MedianCalculate()
        {
            return data =>
            {
                List<double> list = data.OrderBy(z => z).ToList();
                if (list.Count % 2 == 0)
                    return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;
                return list[list.Count / 2];
            };
        }

        public static Calculus<MeanAndStd> mas = new Calculus<MeanAndStd>("Mean and Std", MasCalculate());

        private static Func<IEnumerable<double>, MeanAndStd> MasCalculate()
        {
            return data =>
            {
                double std = Math.Sqrt(data.Select(z => Math.Pow(z - data.Average(), 2)).Sum() / (data.ToList().Count - 1));
                return new MeanAndStd
                {
                    Mean = data.Average(),
                    Std = std
                };
            };
        }
    }
}