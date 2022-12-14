using System;
using System.IO;

namespace Diary_algoritmy
{
    public static class ControlCommands
    {
        
        public static void Start(Diary diar)
        {
            bool isReady = false;
            
            while (true)
            {
                Console.Clear();
                BasicCommands.WriteText();
                diar.CountOfNodes();
                Console.WriteLine();
                
                if (isReady && diar.DiaryNodes.Count != 0)
                {
                    diar.WriteCurrentNode();
                }
                
                HandleCommand(BasicCommands.TypeCommand(),diar, out isReady);
                
                
            }
        }
        
        
        public static void HandleCommand(string command, Diary diar, out bool isReady)
        {
            switch(command)
            {
                case "predchozi":
                    diar.PreviousRecord();
                    break;
                
                case "dalsi":
                    diar.NextRecord();
                    break;
                
                case "novy":
                    diar.NewRecord(BasicCommands.TypeDate(), BasicCommands.TypeText());
                    break;
                
                case "smaz":
                    Console.Clear();
                    diar.WriteCurrentNode();
                    Console.WriteLine("Pro odstranění tohoto záznamu stiskni 'enter', pro zrušení jiný znak.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        diar.DeleteRecord();
                    }
                    else
                    {
                        Console.WriteLine("Zrušeno!");
                    }
                    break;
                
                case "zavri":
                    diar.SaveFile();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Zadali jste špatný příkaz, zkuste to znovu");
                    break;
            }

            isReady = true;

        }
    }
}