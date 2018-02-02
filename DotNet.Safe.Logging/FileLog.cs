using System;
using System.Globalization;
using System.IO;

namespace DotNet.Safe.Logging
{
    /// <summary>
    /// Write logs to a file.
    /// </summary>
    public class FileLog : Log
    {
        private readonly string _uri;
        private readonly Severity _s;

        /// <summary>
        /// Create a log to the specified file with a severity level.
        /// </summary>
        /// <param name="uri">Path to the file</param>
        /// <param name="s">Severity level</param>
        public FileLog(string uri, Severity s)
        {
            _uri = uri;
            _s = s;
        }

        /// <summary>
        /// Writes log messages to the file.
        /// </summary>
        /// <param name="text">Message content</param>
        /// <param name="severity">Message severity</param>
        public override void Print(string text, Severity severity)
        {
            if (severity <= _s)
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(_uri, FileMode.Append)))
                {
                    sw.WriteLine($"[{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss:ff", CultureInfo.InvariantCulture)}] {text}");
                }
            }
        }
    }
}
