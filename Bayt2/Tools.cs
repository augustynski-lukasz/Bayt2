using System;
using System.Diagnostics;

namespace Bayt2
{
    public static class Tools
    {
        public static double GetProgramLifetime()
        {
            var tol = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            return tol.TotalSeconds;
        }
    }
}