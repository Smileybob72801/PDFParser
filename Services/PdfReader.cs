using PDFParser.FileManagement;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace PDFParser
{
	internal class PdfReader(IFileFinder fileFinder) : IPdfReader
	{
		private readonly IFileFinder _fileFinder = fileFinder;

		public List<string> Read(string filePath, string pattern)
		{
			List<string> result = [];

			foreach (string pdfFilePath in _fileFinder.GetFilePaths(filePath, pattern))
			{
				using PdfDocument document = PdfDocument.Open(pdfFilePath);

				foreach (Page page in document.GetPages())
				{
					result.Add(page.Text);
				}
			}

			return result;
		}
	}
}
