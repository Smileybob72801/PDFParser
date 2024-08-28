namespace PDFParser.Tickets
{
	internal interface ITicketWriter
	{
		void Write(List<TicketInfo> tickets, string filePath, string fileName);
	}
}
