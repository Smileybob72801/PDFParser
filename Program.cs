using PDFParser.FileManagement;

namespace PDFParser
{
    internal static class Program
	{
		const string pdfFilePath = "Tickets";
		const string pdfPattern = "*.pdf";
		static void Main()
		{
			IFileFinder fileFinder = new FileFinder();

			string[] pdfs = fileFinder.GetFilePaths(pdfFilePath, pdfPattern);

			Console.ReadKey();
		}
	}
}
