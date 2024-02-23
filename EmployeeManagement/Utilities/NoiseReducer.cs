/*
 Applcation Insights Monitors an applications uptime by using multiple App Insight URL pings
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace EmployeeManagement.Utilities
{
    public class NoiseReducer : ITelemetryProcessor
    {

        private readonly ITelemetryProcessor Next;
        public NoiseReducer(ITelemetryProcessor next)
        {
            Next = next;
        }

        public void Process(ITelemetry item)
        {
            var request = item as RequestTelemetry;
            if (request == null || !request.Url.AbsolutePath.EndsWith("status"))
            {
                Next.Process(item);
            }
        }
    }
}
