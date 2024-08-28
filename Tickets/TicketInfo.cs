namespace PDFParser.Tickets
{
	internal class TicketInfo
    {
        public string? Title { get; set; }
        public DateTime DateTime { get; set; }
		public DateOnly Date {  get; set; }
		public TimeOnly Time { get; set; }

		public override string ToString()
		{
			return $"{Title?.PadRight(30)} | {Date,-12:d} | {Time,-8:HH:mm}";
		}
	}
}
