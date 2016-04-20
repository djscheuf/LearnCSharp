using DJS.Common.Enums;

namespace DJS.Common.Interfaces
{
    public interface ILogger
    {
        void Log(Verbosity level, string message);

        void UpdateVerbosity(Verbosity level);
    }
}
