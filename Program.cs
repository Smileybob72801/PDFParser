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
}
