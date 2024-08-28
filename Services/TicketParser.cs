using System.Globalization;
using System.Text.RegularExpressions;
using PDFParser.Tickets;

namespace PDFParser
{
	internal partial class TicketParser : ITicketParser
	{
		public List<TicketInfo> ParseTickets(List<string> pdfStrings)
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

					DateOnly.TryParse(date, currentCulture, out DateOnly dateOnly);
					string normalizedDate = dateOnly.ToString(CultureInfo.InvariantCulture);

					TimeOnly.TryParse(time, currentCulture, out TimeOnly timeOnly);
					string normalizedTime = timeOnly.ToString(CultureInfo.InvariantCulture);

					tickets.Add(new TicketInfo
					{
						Title = title,
						Date = DateOnly.Parse(normalizedDate),
						Time = TimeOnly.Parse(normalizedTime)
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
