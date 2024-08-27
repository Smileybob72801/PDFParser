using System.Text;

namespace PDFParser.Tickets
{
	internal class TicketWriterTxt : ITicketWriter
	{
		public void Write(List<TicketInfo> tickets, string filePath)
		{
			StringBuilder sb = new();

			foreach (TicketInfo ticket in tickets)
			{
				sb.AppendLine(ticket.ToString());
			}

			File.WriteAllText(filePath, sb.ToString());
		}
	}
}
