using System;
using System.Diagnostics;

namespace injector
{
    public static class ProcessHandler
    {
        public static string GetProcessInput()
        {
            Console.WriteLine("Provide process name or PID: ");
            return Console.ReadLine();
        }

        public static Process FindProcess(string input)
        {
            Process process = null;
            if (int.TryParse(input, out int pid))
            {
                try
                {
                    process = Process.GetProcessById(pid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured while finding process with PID {pid}: {ex.Message}");
                }
            }
            else
            {
                var processes = Process.GetProcessesByName(input);
                if (processes.Length > 0)
                {
                    process = processes[0];
                }
            }
            return process;
        }
    }
}
