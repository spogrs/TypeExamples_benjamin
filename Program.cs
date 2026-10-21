using TypeExamples;

namespace ConsoleApp_typedemo_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
                      
            Console.Write("Hvilket ord skal der søges efter: ");
            var soegeWord = Console.ReadLine();
           
            Console.Write("Hvilket tekst skal der søges i: ");
            string hoestakTekst = Console.ReadLine();
            
            var antalForekomster = Result.WordCount<var>(soegeWord, hoestakTekst);
            bool? countState = checkCount(antalForekomster);
            
                if (countState == null)
                {
                    Console.WriteLine("Det søgte ord findes ikke i den angivne tekst.");
                }
                else
                {
                    Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {antalForekomster} gange.");
                    if ((bool)countState)
                    {
                        //// Source - https://stackoverflow.com/a/19329696
                        //// Posted by xxbbcc, modified by community. See post 'Timeline' for change history
                        //// Retrieved 2026-10-18, License - CC BY-SA 3.0

                        ////string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        ////string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        //string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                        //string fileName = Path.Combine(path, @"..\..\..\typedemo_02.txt");

                        //System.IO.File.WriteAllText(fileName, soegeWord);

                        // can make it nameable
                        string fileName = "typedemo_02";

                        Saver saver = new Saver(hoestakTekst, fileName);

                        Console.Write("Press 1 to save to Solution folder\nPress any key to save to dokuments folder");
                        if (ConsoleKey.D1 == Console.ReadKey(true).Key)
                        {
                            saver.Save(@"..\..\..\" + fileName + ".txt");
                        }
                        else
                        {
                            // if no arg sends to dokuments folder
                            saver.Save();
                        }
                    }
                }
        }
         public class Result
        {
           public static T WordCount<T>(string ord, string tekst)
            {
                int count = 0;
                int index = 0;

                if (ord.Length == 0)
                {
                    Console.WriteLine("Dit søge ord skal være mindst 1 tegn\n\nTryk på en tast for a slukke programmet");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }

                if (tekst.Length == 0)
                {
                    Console.WriteLine("Din tekst skal være mindst 1 tegn\n\nTryk på en tast for a slukke programmet");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }

                while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    count++;
                    index += ord.Length;
                }
                return (T) Convert.ChangeType(count, typeof(T));
            }
        }
        static bool? checkCount(int count)
        {
            if (count == 0)
            {
                return null;
            }
            else if (count < 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
