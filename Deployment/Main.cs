using Finivation.Concert.Agent;
using Finivation.Concert.EventTracing;
using Finivation.Concert.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployment
{
    class Program
    {
        static void Main(string[] args)
        {
            var machineInfo = MiscHelper.GetMachineInfo();
            Agent agent = new Agent(machineInfo.HostName);

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]) && File.Exists(args[0]))
            {
                agent.ConfigurationJsonFullPath = args[0];
            }

            FinivationConcertEventSource.Log.AgentServiceStarts(FinivationConcertEventSource.Log.DomainId, machineInfo.HostName);

            agent.OnStart();

            Console.WriteLine("Concert Agent Console started. Press any key to quit...");
            Console.ReadLine();

            agent.OnStop();
        }
    }
}
