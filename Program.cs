using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Diary_algoritmy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Diary Diar = new Diary("text.txt");
            ControlCommands.Start(Diar);
            
            Console.ReadKey();
        }
    }
}