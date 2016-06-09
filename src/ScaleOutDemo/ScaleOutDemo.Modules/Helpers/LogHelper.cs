using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Common.Utility.Logging;
using XSockets.Plugin.Framework;

namespace ScaleOutDemo.Modules.Helpers
{
    /// <summary>
    /// Just a simple logger for having shorter access to serilog. Only for this demo
    /// </summary>
    public static class LogHelper
    {
        public static void Log(string message)
        {
            Composable.GetExport<IXLogger>().Information(message);
        }
    }
}
