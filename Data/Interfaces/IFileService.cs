

namespace Data.Interfaces;

public interface IFileService
{
    string GetContentFromFile();
    bool SaveContentToFile(string content);

}
