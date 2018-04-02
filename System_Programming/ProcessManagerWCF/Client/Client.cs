using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;

namespace ProcessManager
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            // Указание, где ожидать входящие сообщения.
            Uri address = new Uri("http://localhost:4000/ProcessManager");

            // Указание, как обмениваться сообщениями.
            BasicHttpBinding binding = new BasicHttpBinding();

            // Создание Адреса Конечной Точки.
            EndpointAddress endpointAddress = new EndpointAddress(address);

            // Создание фабрики каналов.
            ChannelFactory<IContract> factory
                = new ChannelFactory<IContract>(binding, endpointAddress);

            // Использование factory для создания канала (прокси).


            // var response = channel.StartProcess("calc");
            // Console.WriteLine(response);
            IContract channel = factory.CreateChannel();

            Console.CursorVisible = false;
            int PID;
           // byte[] arrBytes;
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
                        Console.WriteLine(channel.GetAllProcesses());
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Enter PID: ");
                        if (Int32.TryParse(Console.ReadLine(), out PID))
                        {
                            Console.WriteLine(channel.GetProcByPID(PID));
                        }
                        else
                        {
                            Console.WriteLine("Not a number");
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Enter name: ");
                        Console.WriteLine(channel.StartProcess(Console.ReadLine()));
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Enter PID: ");
                        if (Int32.TryParse(Console.ReadLine(), out PID))
                        {
                            Console.WriteLine(channel.StopProcessByPID(PID));
                        }
                        else
                        {
                            Console.WriteLine("Not a number");
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Enter PID: ");
                        if (Int32.TryParse(Console.ReadLine(), out PID))
                        {
                            Console.WriteLine(channel.GetInfoAboutThreadsByPID(PID));
                        }
                        else
                        {
                            Console.WriteLine("Not a number");
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Enter PID: ");
                        if (Int32.TryParse(Console.ReadLine(), out PID))
                        {
                            Console.WriteLine(channel.GetInfoAboutModulesByPID(PID));
                        }
                        else
                        {
                            Console.WriteLine("Not a number");
                        }
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
