using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunAdmin
{
    public class RunAdmin
    {
        public static void RunAsAdmin(string filename, string arguments, bool wait)
        {
            
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
            processInfo.Verb = "runas";
            processInfo.Arguments = arguments;
            processInfo.FileName = filename;

            System.Diagnostics.Process.Start(processInfo);
            if (wait == true) { System.Diagnostics.Process.Start(processInfo).WaitForExit(); }
        }
    }
}
