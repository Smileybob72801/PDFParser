namespace PDFParser
{
	internal interface IPdfReader
	{
		List<string> Read(string filePath, string pattern);
	}
}
