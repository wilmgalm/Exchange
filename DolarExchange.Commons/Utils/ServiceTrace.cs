using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DolarExchange.Commons.Utils
{
    public class ServiceTrace
    {
        public static void TraceError(string message)
        {
            if (message != null)
                Trace.TraceError(message.ToString());
        }

        public static void TraceError(string format, params object[] args)
        {
            // Use StringBuilder for concatenation in tight loops.
            StringBuilder message = new StringBuilder();
            message.AppendLine(format);
            foreach (object parameter in args)
            {
                if (parameter != null)
                    message.AppendLine(parameter.ToString());
            }
            Trace.TraceError(message.ToString());
        }

        public static void TraceInformation(string message)
        {
            Trace.TraceInformation(message);
        }

        public static void TraceInformation(string format, params object[] args)
        {
            // Use StringBuilder for concatenation in tight loops.
            StringBuilder message = new StringBuilder();
            message.AppendLine(format);
            foreach (object parameter in args)
            {
                if (parameter != null)
                    message.AppendLine(parameter.ToString());
            }
            Trace.TraceInformation(message.ToString());
        }

        public static void TraceWarning(string message)
        {
            Trace.TraceWarning(message);
        }

        public static void TraceWarning(string format, params object[] args)
        {
            // Use StringBuilder for concatenation in tight loops.
            StringBuilder message = new StringBuilder();
            message.AppendLine(format);
            foreach (object parameter in args)
            {
                if (parameter != null)
                    message.AppendLine(parameter.ToString());
            }
            Trace.TraceWarning(message.ToString());
        }

        public static void Write(string message)
        {
            Trace.Write(message);
        }

        public static void Write(object value)
        {
            if (value != null)
                Trace.Write(value.ToString());
        }

        public static void Write(string message, string category)
        {
            Trace.Write(message, category);
        }

        public static void Write(object value, string category)
        {
            if (value != null)
                Trace.Write(value.ToString(), category);
        }

    }
}
