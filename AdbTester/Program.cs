using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADB;

namespace AdbTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adb adb = new Adb();

            adb.InitalStatusCheck();

            Console.ReadKey();
        }
    }
}
