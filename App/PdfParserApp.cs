using PDFParser.Services;
using PDFParser.Tickets;

namespace PDFParser.App
{
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
