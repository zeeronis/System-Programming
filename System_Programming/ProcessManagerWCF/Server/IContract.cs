using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string GetAllProcesses();
        [OperationContract]
        string GetProcByPID(int PID);

        [OperationContract]
        string StopProcessByPID(int PID);
        [OperationContract]
        string StartProcess(string Name);

        [OperationContract]
        string GetInfoAboutThreadsByPID(int PID);
        [OperationContract]
        string GetInfoAboutModulesByPID(int PID);
    }
}
