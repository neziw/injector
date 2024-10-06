using Reloaded.Injector;
using System;
using System.Threading.Tasks;

namespace injector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DLL Injector ===");

            string processNameOrId = ProcessHandler.GetProcessInput();
            var process = ProcessHandler.FindProcess(processNameOrId);
            if (process == null)
            {
                Console.WriteLine("Couldn't find provided process.");
                AbortApplication();
                return;
            }

            string dllPath = DllHandler.GetDllPath();
            if (!DllHandler.ValidateDllPath(dllPath))
            {
                Console.WriteLine("Couldn't find provided DLL.");
                AbortApplication();
                return;
            }

            Console.WriteLine("Injecting DLL file into process...");

            Injector injector = new Injector(process);
            long c = injector.Inject(dllPath);

            if (c == 0)
            {
                Console.WriteLine("Failed to inject DLL file into process.");
            }
            else
            {
                Console.WriteLine("Injected.");
            }

            AbortApplication();
        }

        static void AbortApplication()
        {
            Console.WriteLine("Aborting in 5 seconds...");
            Task.Delay(5000).Wait();
            Environment.Exit(0);
        }
    }
}