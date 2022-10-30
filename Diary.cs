using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Diary_algoritmy
{
    public class Diary
    {
        public static string Path = "";
        public LinkedList<string> DiaryNodes;
        public LinkedListNode<string> CurrentNode;

        public Diary(string savePath)
        {
            
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Close();
            }
            
            
            if (File.ReadAllText(savePath).Length == 0)
            {
                DiaryNodes = new LinkedList<string>();
            }
            else
            {
                var file = File.ReadAllText(savePath);
                DiaryNodes = new LinkedList<string>(file.Split('/'));
                CurrentNode = DiaryNodes.Last;
                //Substring(0,file.LastIndexOf('/')).
            }
            Path = savePath;
        }
        
        
        //methods
        public void NewRecord(string datum, string text)
        {
            DiaryNodes.AddLast($"Datum: {datum} \nText: {text} \n");
            CurrentNode = DiaryNodes.Last;
            SaveFile();
        }

        public void DeleteRecord()
        {
            DiaryNodes.Remove(CurrentNode);
            CurrentNode = DiaryNodes.First;
            SaveFile();
        }
        
        
        public void NextRecord()
        {
            if (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
            }
            else if (CurrentNode == DiaryNodes.Last)
            {
                CurrentNode = DiaryNodes.First;
            }
            else
            {
                CurrentNode = DiaryNodes.Last;
            }
        }

        public void PreviousRecord()
        {
            if (CurrentNode.Previous != null)
            {
                CurrentNode = CurrentNode.Previous;
            }
            else if (CurrentNode == DiaryNodes.First)
            {
                CurrentNode = DiaryNodes.Last;
            }
            else
            {
                CurrentNode = DiaryNodes.First;
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

        private void SaveFile()
        {
            File.WriteAllText(Path, String.Join("/ ", DiaryNodes));
        }
        

    }
    
}