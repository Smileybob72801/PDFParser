namespace PDFParser.FileManagement
{
    internal interface IFileFinder
    {
        string[] GetFilePaths(string filePath, string pattern);
    }
}