using System;
using System.Collections.Generic;
using System.IO;

namespace Diary_algoritmy
{
    public class Diary
    {
        public static string Path = "";
        public LinkedList<string> DiaryNodes;
        public LinkedListNode<string> CurrentNode = null;

        public Diary(string savePath)
        {
            
            if (!File.Exists(savePath))
            {
                File.Create(savePath);
            }
            
            
            if (File.ReadAllText(savePath).Length == 0)
            {
                DiaryNodes = new LinkedList<string>();
            }
            else
            {
                var file = File.ReadAllText(savePath);
                DiaryNodes = new LinkedList<string>(file.Substring(0,file.LastIndexOf('/')).Split('/'));
            }
            Path = savePath;
        }
        
        
        
        //methods
        public void NewRecord(string datum, string text)
        {
            File.AppendAllText(Path, $"Datum: {datum} \nText: {text}/\n");
            DiaryNodes.AddLast($"Datum: {datum} \nText: {text}\n");
        }

        public void NextRecord()
        {
            if (DiaryNodes.Count != 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            else
            {
                CurrentNode = DiaryNodes.Last;
            }

        }
        
        
        
        public void CountOfNodes()
        {
                Console.WriteLine($"Počet záznamů: {DiaryNodes.Count}");
        }


        public void WriteCurrentNode()
        {
            Console.WriteLine(CurrentNode.Value);
            BasicCommands.WriteDash();
            Console.WriteLine("");
        }

    }
    
}