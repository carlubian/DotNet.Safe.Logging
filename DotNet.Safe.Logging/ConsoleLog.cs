using System;

namespace DotNet.Safe.Logging
{
    /// <summary>
    /// Writes logs to the console.
    /// </summary>
    public class ConsoleLog : Log
    {
        private readonly Severity _s;
        private readonly ConsoleColor _default;

        /// <summary>
        /// Create a log to the console with a severity level.
        /// </summary>
        /// <param name="s">Severity level</param>
        public ConsoleLog(Severity s)
        {
            _s = s;
            _default = Console.ForegroundColor;
        }

        /// <summary>
        /// Writes log messages to the console.
        /// </summary>
        /// <param name="text">Message content</param>
        /// <param name="severity">Message severity</param>
        public override void Print(string text, Severity severity)
        {
            if(severity <= _s)
            {
                switch(severity)
                {
                    case Severity.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Severity.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Severity.Info:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Severity.Trace:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    default:
                        Console.ForegroundColor = _default;
                        break;
                }

                Console.WriteLine(text);

                Console.ForegroundColor = _default;
            }
        }
    }
}
