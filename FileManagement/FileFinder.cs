using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace PDFParser.FileManagement
{
    internal class FileFinder : IFileFinder
    {
        public string[] GetFilePaths(string filePath, string pattern) =>
            Directory.GetFiles(filePath, pattern);
	}
}
