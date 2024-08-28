using System.Text;

namespace PDFParser.Tickets
{
	internal class TicketWriterTxt : ITicketWriter
	{
		public void Write(List<TicketInfo> tickets, string filePath, string fileName)
		{
			StringBuilder sb = new();

			foreach (TicketInfo ticket in tickets)
			{
				sb.AppendLine(ticket.ToString());
			}

			string path = Path.Combine(filePath, fileName);

			File.WriteAllText(path, sb.ToString());
		}
	}
}
