namespace PDFParser.Tickets
{
	internal class TicketInfo
    {
        public string? Title { get; set; }
        public DateTime DateTime { get; set; }

		public override string ToString()
		{
			return $"{Title?.PadRight(30)} | {DateTime,-12:d} | {DateTime,-8:HH:mm}";
		}
	}
}
