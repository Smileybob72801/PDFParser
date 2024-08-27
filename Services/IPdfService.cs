using PDFParser.Tickets;

namespace PDFParser.Services
{
    internal interface IPdfService
    {
        List<TicketInfo> PdfsToTickets(string pdfFilePath);
    }
}
