using DotNet.Safe.Standard.Events;

namespace DotNet.Safe.Logging
{
    /// <summary>
    /// Logs events to various sources.
    /// </summary>
    public abstract class Log : CompositionListener
    {
        /// <summary>
        /// Write the output to the system console.
        /// </summary>
        /// <param name="s">Logging granularity</param>
        /// <returns>Console logger</returns>
        public static Log ToConsole(Severity s = Severity.Error) => new ConsoleLog(s);
        /// <summary>
        /// Write the output to a file.
        /// </summary>
        /// <param name="uri">Filename, including path</param>
        /// <param name="s">Logging granularity</param>
        /// <returns></returns>
        public static Log ToFile(string uri, Severity s = Severity.Error) => new FileLog(uri, s);

        /// <summary>
        /// Concrete classes must override this method to write
        /// the logging messages to their intended destination.
        /// </summary>
        /// <param name="text">Message to be logged</param>
        /// <param name="severity">Severity of the message</param>
        public abstract void Print(string text, Severity severity);


        /// <summary>
        /// The composition has started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnCompositionStarted(object sender, CompositionStatus args)
        {
            Print("Composition has started executing", Severity.Info);
        }

        /// <summary>
        /// The composition has finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnCompositionFinished(object sender, CompositionStatus args)
        {
            Print("Composition has finished executing", Severity.Info);
        }

        /// <summary>
        /// A step begins invocation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnStepBeginInvocation(object sender, CompositionStep args)
        {
            Print($"Step {args.Number} has started executing", Severity.Trace);
        }

        /// <summary>
        /// A step ends invocation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnStepEndInvocation(object sender, CompositionStep args)
        {
            Print($"Step {args.Number} has finished executing", Severity.Trace);
        }

        /// <summary>
        /// A step is ignored because of a failing composition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnStepIgnored(object sender, CompositionStep args)
        {
            Print($"Composition has failed, so step {args.Number} is ignored", Severity.Warning);
        }

        /// <summary>
        /// A step fails during execution.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnStepFailure(object sender, CompositionError args)
        {
            Print($"Step {args.Number} has failed with the error: {args.ErrorMessage}", Severity.Error);
        }

        /// <summary>
        /// An otherwise begins invocation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnOtherwiseBeginInvocation(object sender, OtherwiseStep args)
        {
            Print($"Otherwise {args.Number} has started executing", Severity.Trace);
        }

        /// <summary>
        /// An otherwise ends invocation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnOtherwiseEndInvocation(object sender, OtherwiseStep args)
        {
            Print($"Otherwise {args.Number} has finished executing", Severity.Trace);
        }

        /// <summary>
        /// An otherwise is ignored bacuse of a successful composition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnOtherwiseIgnored(object sender, OtherwiseStep args)
        {
            Print($"Composition is successful, so Otherwise {args.Number} is ignored", Severity.Warning);
        }

        /// <summary>
        /// An otherwise fails during execution.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnOtherwiseFailure(object sender, CompositionError args)
        {
            Print($"Otherwise {args.Number} has failed with error: {args.ErrorMessage}", Severity.Error);
        }
    }
}
