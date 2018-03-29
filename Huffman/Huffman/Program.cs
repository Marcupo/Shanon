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


        public static string LireFichier(string chemin)
        {
            return File.ReadAllText(chemin);
        }

        public static Dictionary<char, int> TrieDico(string text)
        {
            Dictionary<char, int> dico = new Dictionary<char, int>();

            foreach (char lettre in text)
            {
                if (!dico.ContainsKey(lettre))
                    dico.Add(lettre, 1);
                else
                    dico[lettre]++;
            }

            var sortedList = from pair in dico orderby pair.Value descending select pair;
            Dictionary<char, int> dicoTrier = new Dictionary<char, int>();
            foreach (KeyValuePair<char, int> lettre in sortedList)
            {
                dicoTrier.Add(lettre.Key, lettre.Value);
            }

            return dicoTrier;
        }

        static void AffichageDico(Dictionary<char, int> dico)
        {
            foreach (char lettre in dico.Keys)
            {
                Console.WriteLine("Lettre : " + lettre.ToString() + " | Recurrence : " + dico[lettre].ToString() + " | Probabilités : " + ((float)dico[lettre] / (float)dico.Count).ToString());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrez le nom du fichier à analyser");
            string fichier = "./test.txt";//Console.ReadLine();
        
            Dictionary<char, int> dico = TrieDico(LireFichier(fichier));

            AffichageDico(dico);

            Console.ReadKey();
        }
        

    }
}
