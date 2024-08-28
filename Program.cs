using PDFParser.App;
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
			ITicketParser ticketParser = new TicketParser();
			IPdfReader pdfReader = new PdfReader(fileFinder);
			IPdfService pdfService = new PdfService(pdfReader, ticketParser);
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
}
