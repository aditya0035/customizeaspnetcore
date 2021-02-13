﻿using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace LoggingSample
{
    public class ColoredConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ColoredConsoleConfiguration _config;
        private ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();
        public ColoredConsoleLoggerProvider(ColoredConsoleConfiguration config)
        {
            _config = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new ColoredConsoleLogger(_config));
        }

        public void Dispose()
        {
            
        }
    }
}

//ILoggerProvider,ILogger