using Microsoft.Extensions.Logging;
using System;

namespace LoggingSample
{
    public class ColoredConsoleConfiguration
    {
        public int EventId { get; set; } = 0;
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public ConsoleColor ConsoleColor { get; set; } = ConsoleColor.Cyan;
        public ColoredConsoleConfiguration()
        {
        }
    }
}