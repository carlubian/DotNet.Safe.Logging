namespace DotNet.Safe.Logging
{
    /// <summary>
    /// Configures the granularity of logging.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Only log errors.
        /// </summary>
        Error,
        /// <summary>
        /// Log errors and warnigns.
        /// </summary>
        Warning,
        /// <summary>
        /// Log most events.
        /// </summary>
        Info,
        /// <summary>
        /// Log a full execution trace.
        /// </summary>
        Trace
    }
}
