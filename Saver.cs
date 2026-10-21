using System;
using System.Collections.Generic;
using System.Text;

namespace TypeExamples
{
    internal class Saver
    {
        string content;
        string fileName;

        public Saver (string content, string fileName)
        {
           this.content = content;
            this.fileName = fileName;
        }

        public void Save()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + fileName + ".txt";
            Console.WriteLine(path);
            Console.ReadKey();
            File.WriteAllText(path, content);
        }
        public void Save(string path)
        {

            File.WriteAllText(path, content);
        }


    }
}
