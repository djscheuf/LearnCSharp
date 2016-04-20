using System.IO;

namespace DJS.Common.Interfaces
{
    public interface IFileManager
    {
        Stream OpenRead(string filename);

        Stream OpenWrite(string filename);
    }
}
