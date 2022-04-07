using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Reports
{
	public abstract class ReportMaker
	{
		protected abstract string MakeCaption(string caption);
		protected abstract string BeginList();
		protected abstract string MakeItem(string valueType, string entry);
		protected abstract string EndList();
		protected abstract object MakeStatistics(IEnumerable<double> data);
		protected abstract string Caption { get; }
		public string MakeReport(IEnumerable<Measurement> measurements)
		{
			var data = measurements.ToList();
			var result = new StringBuilder();
			result.Append(MakeCaption(Caption));
			result.Append(BeginList());
			result.Append(MakeItem("Temperature", MakeStatistics(data.Select(z => z.Temperature)).ToString()));
			result.Append(MakeItem("Humidity", MakeStatistics(data.Select(z => z.Humidity)).ToString()));
			result.Append(EndList());
			return result.ToString();
		}
	}

	public class MeanAndStdHtmlReportMaker : ReportMaker
	{
		protected override string Caption
		{
			get
			{
				return "Mean and Std";
			}
		}

		protected override string MakeCaption(string caption)
		{
			return $"<h1>{caption}</h1>";
		}

		protected override string BeginList()
		{
			return "<ul>";
		}

		protected override string EndList()
		{
			return "</ul>";
		}

		protected override string MakeItem(string valueType, string entry)
		{
			return $"<li><b>{valueType}</b>: {entry}";
		}

		protected override object MakeStatistics(IEnumerable<double> _data)
		{
			var data = _data.ToList();
			var mean = data.Average();
			var std = Math.Sqrt(data.Select(z => Math.Pow(z - mean, 2)).Sum() / (data.Count - 1));

			return new MeanAndStd
			{
				Mean = mean,
				Std = std
			};
		}
	}

	public class MedianMarkdownReportMaker : ReportMaker
	{
		protected override string Caption
		{
			get
			{
				return "Median";
			}
		}

		protected override string BeginList()
		{
			return "";
		}

		protected override string EndList()
		{
			return "";
		}

		protected override string MakeCaption(string caption)
		{
			return $"## {caption}\n\n";
		}

		protected override string MakeItem(string valueType, string entry)
		{
			return $" * **{valueType}**: {entry}\n\n";
		}

		protected override object MakeStatistics(IEnumerable<double> data)
		{
			var list = data.OrderBy(z => z).ToList();
			if (list.Count % 2 == 0)
				return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;
			
			return list[list.Count / 2];
		}
	}

	public static class ReportMakerHelper
	{
		public static string MeanAndStdHtmlReport(IEnumerable<Measurement> data)
		{
			return new MeanAndStdHtmlReportMaker().MakeReport(data);
		}

		public static string MedianMarkdownReport(IEnumerable<Measurement> data)
		{
			return new MedianMarkdownReportMaker().MakeReport(data);
		}

		public static string MeanAndStdMarkdownReport(IEnumerable<Measurement> measurements)
		{
			throw new NotImplementedException();
		}

		public static string MedianHtmlReport(IEnumerable<Measurement> measurements)
		{
			throw new NotImplementedException();
		}
	}
}
