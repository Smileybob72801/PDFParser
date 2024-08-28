using PDFParser.FileManagement;
using PDFParser.Services;
using System.Globalization;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using PDFParser.Tickets;

namespace PDFParser
{
    internal partial class PdfService(IFileFinder fileFinder) : IPdfService
	{
		const string pdfPattern = "*.pdf";
		private readonly IFileFinder _fileFinder = fileFinder;

		public List<TicketInfo> PdfsToTickets(string pdfFilePath)
		{
			List<string> pdfContentsAsStrings = PdfToString(pdfFilePath, pdfPattern);
			return StringsToTickets(pdfContentsAsStrings);
		}

		private List<string> PdfToString(string filePath, string pattern)
		{
			List<string> result = [];

			foreach (string pdfFilePath in _fileFinder.GetFilePaths(filePath, pattern))
			{
				using PdfDocument document = PdfDocument.Open(pdfFilePath);

				foreach (Page page in document.GetPages())
				{
					result.Add(page.Text);
				}
			}

			return result;
		}

		private static List<TicketInfo> StringsToTickets(List<string> pdfStrings)
		{
			List<TicketInfo> tickets = [];

			foreach (string pdfString in pdfStrings)
			{
				CultureInfo currentCulture = GetCultureFromPdfString(pdfString);

				foreach (Match match in TicketPattern().Matches(pdfString).Cast<Match>())
				{
					string title = match.Groups["Title"].Value.Trim();
					string date = match.Groups["Date"].Value.Trim();
					string time = match.Groups["Time"].Value.Trim();

					string combinedDateTime = $"{date} {time}";

					_ = DateTime.TryParse(combinedDateTime, currentCulture, out DateTime dateTime);
					string invariantDate = dateTime.ToString(CultureInfo.InvariantCulture);

					tickets.Add(new TicketInfo
					{
						Title = title,
						DateTime = DateTime.Parse(invariantDate)
					});
				}
			}

			return tickets;
		}

		private static CultureInfo GetCultureFromPdfString(string pdfString)
		{
			Match match = UrlPattern().Match(pdfString);

			if (match.Success)
			{
				string url = match.Groups[1].Value.Trim();

				if (url.EndsWith(".com"))
				{
					return new CultureInfo("en-US");
				}
				else if (url.EndsWith(".jp"))
				{
					return new CultureInfo("jp-JP");
				}
				else if (url.EndsWith(".fr"))
				{
					return new CultureInfo("fr-FR");
				}
			}

			return CultureInfo.InvariantCulture;
		}

		[GeneratedRegex(@"Title:(?<Title>.*?)Date:(?<Date>.*?)Time:(?<Time>.*?)(?=Title:|Visit|$)")]
		private static partial Regex TicketPattern();

		[GeneratedRegex("Visit\\s+us:\\s*(www\\.[^\\s]+)")]
		private static partial Regex UrlPattern();
	}
}
