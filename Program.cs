using PDFParser.FileManagement;
using PDFParser.Services;
using PDFParser.Tickets;

namespace PDFParser
{
    internal static class Program
	{
		static void Main()
		{
			IFileFinder fileFinder = new FileFinder();
			IPdfService pdfService = new PdfService(fileFinder);
			ITicketWriter ticketWriter = new TicketWriterTxt();

			PdfParserApp app = new(pdfService, ticketWriter);

			try
			{
				app.Run();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}

	internal class PdfParserApp(IPdfService pdfService, ITicketWriter ticketWriter)
	{
		const string PdfFilePath = "Tickets";
		const string OutputFilePath = "tickets.txt";

		private readonly IPdfService _pdfService = pdfService;
		private readonly ITicketWriter _ticketWriter = ticketWriter;

		public void Run()
		{
			List<TicketInfo> ticketInfos = _pdfService.PdfsToTickets(PdfFilePath);

			_ticketWriter.Write(ticketInfos, OutputFilePath);

			Console.ReadKey();
		}
	}
}
