using System;
using System.ServiceModel;

namespace Chat_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCF.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("host is started");
                Console.ReadLine();
            }
        }
    }
}
