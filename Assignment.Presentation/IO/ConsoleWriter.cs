using Assignment.Contracts;
using System;

namespace Assignment.IO
{
    /// <summary>
    /// it best to abstract the console read to respect the SOLID principles
    /// </summary>
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
        public void Write(string output)
        {
            Console.Write(output);
        }
    }
}
