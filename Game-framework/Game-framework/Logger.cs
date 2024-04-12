using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class Logger
    {
        private static Logger _instance;
        private TraceSource _traceSource;

        // Private ctor for singleton pattern
        private Logger()
        {
            //_traceSource = new TraceSource("GameTraceSource");
            //_traceSource.Listeners.Add(new ConsoleTraceListener());
            _traceSource = new TraceSource("Gamess", SourceLevels.All);
            _traceSource.Listeners.Add(new ConsoleTraceListener());
            _traceSource.Listeners[0].TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Timestamp;
            _traceSource.Listeners[0].Name = "Consoel";
        }

        // Property to access singleton instance
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public void AddTraceListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }

        public void RemoveTraceListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
        }

        public void LogInformation(string message)
        {
            _traceSource.TraceInformation(message);
            _traceSource.Flush();
        }

        public void LogWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 0, message);
            _traceSource.Flush();
        }

        public void LogError(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, message);
            _traceSource.Flush();
        }
    }
}
