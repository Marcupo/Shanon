/*
 *  Auteurs : Vlajkovic Marco et Paschoud Nicolas
 *  Nom du Programme : Huffman
 *  Description : Ce programme permet de compresser un texte selon la méthode de Huffman
 *  Date : 29.03.2018
 *  Version : 1.0
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

        public static Dictionary<char, double> TrieDico(string text)
        {
            Dictionary<char, double> dico = new Dictionary<char, double>();

            foreach (char lettre in text)
            {
                if (!dico.ContainsKey(lettre))
                    dico.Add(lettre, 1);
                else
                    dico[lettre]++;
            }

            for(int i = 0; i < dico.Count; i++)
            {
                char lettre = dico.ElementAt(i).Key;
                dico[lettre] = (dico[lettre] / text.Length);
            }

            return dico;
        }

        static void AffichageDico(Dictionary<char, double> dico)
        {
            foreach (char lettre in dico.Keys)
            {
                Console.WriteLine("Lettre : " + lettre.ToString() + " | Proba : " + dico[lettre].ToString());
            }
        }

        static double EntropieCalcul(Dictionary<char, double> dico, int longueurText)
        {
            double entropie = 0f;
            foreach (double proba in dico.Values)
            {
                entropie += -Math.Log(proba, 2) * proba;
            }
            return entropie;
        }

        public struct TreeContent
        {
            public char Key { get; set; }
            public double Proba { get; set; }
    };

        public static List<TreeContent> CreateTree(Dictionary<char, double> dico)
        {
            Console.WriteLine("_______");
            List<TreeContent> Huffman = new List<TreeContent>();
            foreach (char chara in dico.Keys)
            {
                Huffman.Add(new TreeContent() { Key = chara , Proba = dico[chara] });
                Console.WriteLine("Chara : "+chara + "Proba : " + dico[chara]);
            }

            return Huffman;
        }

        public static List<TreeContent> TriParTas(List<TreeContent> list)
        {
            TreeContent temp;
            for (int i = 0; i < list.Count; i++)
            {
                list = Tas(list,list.Count-i);
                temp = list[0];
                list[0] = list[list.Count- i];
                list[list.Count - i] = temp;
            }
            
            return list;
        }

        public static List<TreeContent> Tas(List<TreeContent> list,int taille)
        {
            for (int i = 1; i < taille; i++)
            {
                list = TriTasParents(list, i);
            }
            return list;
        }

        public static List<TreeContent> TriTasParents(List<TreeContent> list,int index)
        {
            double x = index / 2;
            int y = (int)Math.Ceiling(x);
            if (list[index].Proba > list[y - 1].Proba)
            {
                TreeContent z = list[index];
                list[index] = list[y - 1];
                list[y - 1] = z;
                if (y != 0)
                    TriTasParents(list, y);
            }
            return list;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrez le nom du fichier à analyser");
            string fichier = "./TheSonnets.txt";//Console.ReadLine();

            string text = LireFichier(fichier);
            int longueurText = text.Length;
            Dictionary<char, double> dico = TrieDico(text);

            AffichageDico(dico);

            double entropie = EntropieCalcul(dico, longueurText);

            Console.WriteLine("Entropie : " + entropie.ToString());

            //CreateTree(dico);

            Console.ReadKey();

        }
        
    }
}