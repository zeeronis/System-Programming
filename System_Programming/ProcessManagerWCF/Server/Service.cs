using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    class Service : IContract
    {
        public string GetAllProcesses()
        {
            string result = "";
            var processList = Process.GetProcesses();
            foreach (var proc in processList)
            {
                result += "PID: " + proc.Id + " Name: " + proc.ProcessName + Environment.NewLine;
            }
            return result;
        }

        public string GetInfoAboutModulesByPID(int PID)
        {
            string result = "Process modules:";
            Process process = null;
            if (GetProcbyPID(ref process, PID))
            {
                var ProcessModules = process.Modules;
                foreach (ProcessModule module in ProcessModules)
                {
                    result += Environment.NewLine + Environment.NewLine +
                        " Module name:: " + module.ModuleName;
                    result += Environment.NewLine + 
                        " -Path: " + module.FileName;
                }
            }
            else
            {
                result = "Process by PID not found";
            }
            return result;
        }

        public string GetInfoAboutThreadsByPID(int PID)
        {
            string result = "Process thread ID's:";
            Process process = null;
            if (GetProcbyPID(ref process, PID))
            {
                var ProcessThreads = process.Threads;
                foreach (ProcessThread thread in ProcessThreads)
                {
                    result += Environment.NewLine + " Id: " + thread.Id;
                }
            }
            else
            {
                result = "Process by PID not found";
            }
            return result;
        }

        public string GetProcByPID(int PID)
        {
            string result = "";
            Process proc = null;
            if (GetProcbyPID(ref proc, PID))
            {
                result += "PID: " + proc.Id + Environment.NewLine
                    + " Name: " + proc.ProcessName + Environment.NewLine
                    + " BasePriority: " + proc.BasePriority + Environment.NewLine;
            }
            else
            {
                result = "process by PID not found";
            }
            return result;
        }

        public string StartProcess(string Name)
        {
            string result = "Err";
            try
            {
                Process.Start(Name);
                result = "Process: " + Name + " Started";
            }
            catch (Exception)
            {
                result ="Process: " + Name +" don't find or access denied";
            }
            return result;
        }

        public string StopProcessByPID(int PID)
        {
            string result = "Err";
            Process process = null;
            if (GetProcbyPID(ref process, PID))
            {
                try
                {
                    process.Kill();
                    result = "Process is killed";
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    result = "Аccess denied";
                }
            }
            else
            {
                result = "process by PID not found";
            }
            return result;
        }


        private bool GetProcbyPID(ref Process proc, int PID)
        {
            try
            {
                proc = Process.GetProcessById(PID);
                return true;
            }
            catch (ArgumentException)
            {
                
            }
            return false;
        }
    }
}
