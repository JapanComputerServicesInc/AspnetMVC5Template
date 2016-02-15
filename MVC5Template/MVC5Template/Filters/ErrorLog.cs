using System;

namespace MVC5Template.Filters
{
    internal class ErrorLog
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string LogMessageGenerator { get; set; }
        public string Stacktrace { get; set; }
        public DateTime Updated { get; set; }
    }
}