using Microsoft.Extensions.Logging;
using System;

namespace LoggingSample
{
    public class ColoredConsoleLogger : ILogger
    {
        private readonly ColoredConsoleConfiguration _config;
        private static readonly object _lock = new object();

        public ColoredConsoleLogger(ColoredConsoleConfiguration config)
        {
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _config.LogLevel == logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                if (_config.EventId == 0||_config.EventId == eventId)
                {
                    lock (_lock)
                    {
                        var prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = _config.ConsoleColor;
                        Console.WriteLine($"{logLevel} - {eventId} - {DateTime.UtcNow} - {formatter(state, exception)}");
                        Console.ForegroundColor = prevColor;
                    }
                }
            }
        }
    }
}