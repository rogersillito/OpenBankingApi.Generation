using System;
using Microsoft.Owin.Hosting;

namespace OpenBankingApi.ConsoleHost
{
    public class Program
    {
        public static int Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://127.0.0.1:12345"))
            {
                Console.ReadLine();
            }
            return 0;
        }
    }
}