using PDFParser.Services;
using PDFParser.Tickets;

namespace PDFParser
{
	internal class PdfService(IPdfReader pdfReader, ITicketParser ticketParser) : IPdfService
	{
		const string pdfPattern = "*.pdf";
		private readonly IPdfReader _pdfReader = pdfReader;
		private readonly ITicketParser  _ticketParser = ticketParser;

		public List<TicketInfo> PdfsToTickets(string pdfFilePath)
		{
			List<string> pdfContentsAsStrings = _pdfReader.Read(pdfFilePath, pdfPattern);
			return _ticketParser.ParseTickets(pdfContentsAsStrings);
		}
	}
}
