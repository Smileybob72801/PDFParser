using PDFParser.Tickets;

namespace PDFParser
{
	internal interface ITicketParser
	{
		List<TicketInfo> ParseTickets(List<string> pdfStrings);
	}
}
