using System;
using System.IO;

namespace injector
{
    public static class DllHandler
    {
        public static string GetDllPath()
        {
            Console.WriteLine("Provide DLL path: ");
            return Console.ReadLine();
        }

        public static bool ValidateDllPath(string dllPath)
        {
            return File.Exists(dllPath);
        }
    }
}
