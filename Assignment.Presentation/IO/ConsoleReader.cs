using Assignment.Contracts;
using System;

namespace Assignment.IO
{
    /// <summary>
    /// it best to abstract the console read to respect the SOLID principles
    /// </summary>
    public class ConsoleReader : IConsoleReader
    {

        public int ReadInteger(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public decimal ReadDecimal(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public string ReadString(string prompt)
        {
            Console.Write(prompt + ": > ");
            return Console.ReadLine();
        }
    }
}
