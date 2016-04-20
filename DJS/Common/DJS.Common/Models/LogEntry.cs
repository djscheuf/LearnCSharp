using System.Windows.Media;

namespace DJS.Common.Models
{
    public class LogEntry
    {
        public LogEntry()
        {
            Message = "";
            Color = Colors.Gray;
        }

        public LogEntry(Color color, string message)
        {
            Message = message;
            Color = color;
        }

        public Color Color;

        public string Message { get; private set; }

        public Brush Brush
        {
            get
            {
                return new SolidColorBrush(Color);
            }
        }

    }
}
