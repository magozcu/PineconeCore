namespace PineconeGames.Core.Zippers
{
    public interface IZipper
    {
        bool ZipFolder(string folderPath);

        bool ExtractZip(string zipFilePath);
    }
}