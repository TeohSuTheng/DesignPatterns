using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<String> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename,j.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j.ToString());

            var p = new Persistence();
            var filename = @"C:\Users\Asus\Desktop\Statutory Forms\journal.txt";
            p.SaveToFile(j, filename, true);
        }
    }
}
