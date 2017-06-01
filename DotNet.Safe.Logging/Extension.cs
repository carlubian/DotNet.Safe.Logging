using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Safe.Standard.Exceptions;

namespace DotNet.Safe.Logging
{
    /// <summary>
    /// Exposes an extensio method to attach a logger to a composition.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Attaches a logging module from DotNet.Safe.Logging to this composition.
        /// </summary>
        /// <typeparam name="TCurrent">Composition type</typeparam>
        /// <param name="source">Composition</param>
        /// <param name="log">Logging module</param>
        /// <returns>In-progress composition</returns>
        public static Composition<TCurrent> UseLogging<TCurrent>(this Composition<TCurrent> source, Log log)
        {
            source.Attach(log);
            return source;
        }
    }
}
