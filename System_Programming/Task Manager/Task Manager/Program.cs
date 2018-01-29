using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Task Manager";

            Process CurrSelectedProc = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Environment.NewLine + 
                                  " Press 1 to get a list of all processes");
                Console.WriteLine(" Press 2 to select the process by PID");
                Console.WriteLine(" Press 3 for start process");
                Console.WriteLine(" Press 4 for stop process by PID");
                Console.WriteLine(" Press 5 for information about threads");
                Console.WriteLine(" Press 6 for get info about modules");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Process list: " + Environment.NewLine);

                        int count = 0;
                        var processList = Process.GetProcesses(".").Select(proc => proc).OrderBy(proc => proc.Id);
                        foreach (var proc in processList)
                        {
                            count++;
                            Console.WriteLine(" PID: " + proc.Id + " Name: " + proc.ProcessName);
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                        if (getProcbyPID(out CurrSelectedProc))
                        {
                            Console.WriteLine("Process Info: ");
                            Console.WriteLine(" ProcessName: " + CurrSelectedProc.ProcessName);
                            Console.WriteLine(" PID: " + CurrSelectedProc.Id);                    
                            Console.WriteLine(" Base Priority: " + CurrSelectedProc.BasePriority);
                            Console.WriteLine(" Handle Count: " + CurrSelectedProc.HandleCount);
                            Console.WriteLine(" Machine Name: " + CurrSelectedProc.MachineName);
                            try
                            {
                                Console.WriteLine(" Total Processor Time" + CurrSelectedProc.TotalProcessorTime);
                                Console.WriteLine(" User Processor Time" + CurrSelectedProc.UserProcessorTime);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(" Total Processor Time: Access denied");
                                Console.WriteLine(" User Processor Time: Access denied");
                            }
                           
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:

                        Console.Clear();
                        Console.Write("Start ");
                        try
                        {
                            Process.Start(Console.ReadLine());
                            Console.WriteLine("Process Started");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Can't find");
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D4:
                        if (getProcbyPID(out CurrSelectedProc))
                        {
                            try
                            {
                                CurrSelectedProc.Kill();
                                Console.WriteLine("Process Killed");
                            }
                            catch (System.ComponentModel.Win32Exception)
                            {
                                Console.WriteLine("Аccess denied");
                            }
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D5:
                        if (getProcbyPID(out CurrSelectedProc))
                        {
                            Console.WriteLine(Environment.NewLine + "Process Threads ID: ");

                            var ProcessThreads = CurrSelectedProc.Threads;
                            foreach (ProcessThread thread in ProcessThreads)
                            {
                                Console.WriteLine(" Id: " + thread.Id);
                            }
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D6:
                        if (getProcbyPID(out CurrSelectedProc))
                        {
                            Console.WriteLine(Environment.NewLine + "Process Modules: ");

                            var processModules = CurrSelectedProc.Modules;
                            foreach (ProcessModule module in processModules)
                            {
                                Console.WriteLine(" Module name: " + module.ModuleName);
                             // Console.WriteLine(" -File version info" + module.FileVersionInfo);
                                Console.WriteLine(" -Path: " + module.FileName);
                                Console.WriteLine(" -Module memory size: " + module.ModuleMemorySize 
                                    + Environment.NewLine);
                            }
                        }
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            }

    }
        private static bool getProcbyPID(out Process proc)
        {
            Console.Clear();
            Console.Write("Enter PID: ");

            proc = null;
            int PID;
            if (Int32.TryParse(Console.ReadLine(), out PID))
            {
                try
                {
                    proc = Process.GetProcessById(PID);
                    return true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(Environment.NewLine + "Process number " + PID + " does not exist");
                }

            }
            else
            {
                Console.WriteLine(" - Not a number");
            }
            return false;
        }

    }
}