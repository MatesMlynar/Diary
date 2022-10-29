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
                
                if (isReady)
                {
                    diar.WriteCurrentNode();
                }
                
                HandleCommand(BasicCommands.TypeCommand(),diar, out isReady);
                
                
                /*if (BasicCommands.TypeCommand() == "ukonci")
                {
                    Console.WriteLine("Deník zavřen!");
                    break;
                }*/
                
            }
        }
        
        
        public static void HandleCommand(string command, Diary diar, out bool isReady)
        {
            switch(command)
            {
                case "predchozi":

                    //do something
                    break;
                
                case "dalsi":
                    diar.NextRecord();
                    
                    break;
                
                case "novy":
                    diar.NewRecord(BasicCommands.TypeDate(), BasicCommands.TypeText());
                    break;
                
                case "smaz":


                    break;
                
                case "zavri":
                    
                    break;
            }

            isReady = true;

        }
    }
}