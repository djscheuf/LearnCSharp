using DJS.Common.Enums;
using DJS.Common.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Media;
using DJS.Common.Models;

namespace DJS.Common.Controllers
{
    public class LoggingController : ILogger
    {
        public LoggingController()
        {
            Tolerance = Verbosity.Info;
            Entries = new ObservableCollection<LogEntry>();
        }

        public Verbosity Tolerance { get; private set; }
        public ObservableCollection<LogEntry> Entries { get; private set; }

        public void Log(Verbosity level, string message)
        {
            if (level < Tolerance)
                return;

            var color = GetColorForLevel(level);

            var prepend = GetPrependForLevel(level);

            Entries.Add(new LogEntry(color, prepend + message));
        }

        private object GetPrependForLevel(Verbosity level)
        {
            switch (level)
            {
                case Verbosity.Info:
                    return "[INFO]";
                case Verbosity.Progress:
                    return "[PRGS]";
                case Verbosity.Warn:
                    return "[WARN]";
                case Verbosity.Error:
                    return "[ERR]";
                default:
                    return "[UKWN]";
            }
        }

        private Color GetColorForLevel(Verbosity level)
        {
            switch (level)
            {
                case Verbosity.Info:
                    return Colors.Gray;
                case Verbosity.Progress:
                    return Colors.CadetBlue;
                case Verbosity.Warn:
                    return Colors.Tomato;
                case Verbosity.Error:
                    return Colors.Red;
                default:
                    return Colors.Black;
            }
        }

        public void UpdateVerbosity(Verbosity level)
        {
            Tolerance = level;
        }
    }
}
