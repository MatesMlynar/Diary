using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Diary_algoritmy
{
    class BasicCommands
    {
        public static void WriteText()
        {
            Console.Clear();
            WriteDash();
            Console.WriteLine();
            Console.WriteLine("Deník se ovládá následujícími příkazy:");
            Console.WriteLine("- predchozi: Přesunutí na předhozí seznam");
            Console.WriteLine("- dalsi: Přesunutí na další záznam");
            Console.WriteLine("- novy: Vytvoření nového záznamu");
            Console.WriteLine("- uloz: Uložení vytvořeného záznamu");
            Console.WriteLine("- smaz: Odstranění záznamu");
            Console.WriteLine("- zavri: Zavření deníku");
            WriteDash();
            Console.WriteLine();
        }

        public static void WriteDash()
        {
            for (int i = 0; i < 60; i++)
            {
                Console.Write('-');
            }
        }


        public static string TypeCommand()
        {
            Console.Write("Zadej příkaz: ");
            string command = Console.ReadLine();
            return command;
        }

        public static string TypeDate()
        {
            DateTime dateResult = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            bool isNotParsed = true;
            
            while (isNotParsed)
            {
                Console.Write("Datum: ");

                if (DateTime.TryParse(Console.ReadLine(), out dateResult))
                {
                    isNotParsed = false; 
                }
                else
                {
                    Console.WriteLine("Datum zadán ve špatném formátu, zkuste to znovu!");
                }
                
            }
            
            return dateResult.ToString();
        }


        public static string TypeText()
        {
            Console.Write("Text: ");
            string returnText = "";
            string inputValue = "";
            bool notReady = true;
            while (notReady)
            {
                inputValue = Console.ReadLine().ToLower();
                if (inputValue == "uloz")
                {
                    Console.WriteLine("Ulozeno!");
                    return returnText;
                }
                else
                {
                    returnText += inputValue + " ";
                }
            }
            return returnText;
        }
    }
}