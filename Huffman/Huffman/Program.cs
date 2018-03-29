/*
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dico = new Dictionary<char, int>();

            Console.WriteLine("Veuillez entrez le nom du fichier à analyser");

            string fichier = "./test.txt";//Console.ReadLine();
            string text = File.ReadAllText(fichier);

            //Console.Write(text);

            foreach (char lettre in text)
            {
                if (!dico.ContainsKey(lettre))
                    dico.Add(lettre, 1);
                else
                    dico[lettre]++;
            }

            // Order by values.
            // ... Use LINQ to specify sorting by value.
            var items = from pair in dico orderby pair.Value descending select pair;

            foreach (KeyValuePair<char, int> pair in items)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }


            /* foreach (char lettre in dico.Keys)
             {
                 Console.WriteLine("Lettre : " + lettre.ToString() + " | Recurrence : " + dico[lettre].ToString()+" | Probabilités : " + ((float)dico[lettre]/(float)dico.Count).ToString());
             }*/

            Console.ReadKey();
        }
    }
}
