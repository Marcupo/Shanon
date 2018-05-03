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

        public static Dictionary<char, double> CreateDico(string text)
        {
            Dictionary<char, double> dico = new Dictionary<char, double>();

            //  Rajoute les lettres dans le dico
            foreach (char lettre in text)
            {
                if (!dico.ContainsKey(lettre))
                    dico.Add(lettre, 1);
                // Si la lettre existe deja augmente son nombre d'occurence
                else
                    dico[lettre]++;
            }

            //  Parcours le dico et fait des trucs bizzare
            for (int i = 0; i < dico.Count; i++)
            {
                char lettre = dico.ElementAt(i).Key;
                //  Remplace l'occurence par la probabilité
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

        //public static TreeContent[] CreateTree(Dictionary<char, double> dico)
        //{
        //    List<TreeContent> ListAInserer = new List<TreeContent>();
        //    TreeContent[] HuffmanTree = new TreeContent[dico.Count];
        //    foreach (char chara in dico.Keys)
        //    {
        //        ListAInserer.Add(new TreeContent() { Key = chara, Proba = dico[chara] });
        //    }

        //    int last = 0;
        //    //  Creation de l'arbre Huffman
        //    for (int i = 0; i < HuffmanTree.Length; i += 2)
        //    {
        //        // ListAInserer.Sort();

        //        last = HuffmanTree.Length - 1 - i;
        //        if (last != 0)
        //        {
        //            HuffmanTree[last] = ListAInserer[last];
        //            HuffmanTree[last - 1] = ListAInserer[last - 1];

        //            ListAInserer.Add(new TreeContent() { Key = ' ', Proba = (ListAInserer[last].Proba + ListAInserer[last - 1].Proba) });

        //            ListAInserer.RemoveAt(ListAInserer.Count - 2);
        //            ListAInserer.RemoveAt(ListAInserer.Count - 2);
        //        }
        //    }

        //    return HuffmanTree;
        //}
        unsafe public struct Noeud
        {
            public double Proba;
            public Noeud* ElementG;
            public Noeud* ElementD;
            public char Lettre;
        };

        public static Dictionary<char, double> TriDico(Dictionary<char, double> dico)
        {
            var sortedList = from pair in dico orderby pair.Value descending select pair;
            Dictionary<char, double> dicoTrier = new Dictionary<char, double>();
            foreach (KeyValuePair<char, double> lettre in sortedList)
            {
                dicoTrier.Add(lettre.Key, lettre.Value);
            }

            return dicoTrier;
        }

        unsafe public static Noeud CreateNoeud(double proba, Noeud* SAG = null, Noeud* SAD = null, char key = '\0')
        {
            Noeud node = new Noeud { Proba = proba, ElementG = SAG, ElementD = SAD, Lettre = key };
            return node;
        }

        unsafe public static List<Noeud> TriListe(List<Noeud> liste)
        {
            var sortedList = from pair in liste orderby pair.Proba descending select pair;
            List<Noeud> listTrier = new List<Noeud>();
            foreach (Noeud cactus in sortedList)
            {
                listTrier.Add(new Noeud { Proba = cactus.Proba, ElementG = cactus.ElementG, ElementD = cactus.ElementD, Lettre = cactus.Lettre });
            }

            return listTrier;

        }

        unsafe public static Noeud CreateTree(Dictionary<char, double> dico)
        {
            Noeud tree = new Noeud();
            List<Noeud> arbre = new List<Noeud>();
            Noeud n;

            foreach (char key in dico.Keys)
            {
                n = new Noeud { Proba = dico[key], ElementG = null, ElementD = null, Lettre = key };
                arbre.Add(n);
            }

            while (arbre != null)
            {
                arbre = TriListe(arbre);


            }

            //Noeud temp;
            //Noeud connexion;

            //while (dico != null) {
            //    dico = TriDico(dico);
            //    Noeud firstNode = createNoeud(dico[dico.Last().Key], null, null, dico.Last().Key);
            //    dico.Remove(dico.Last().Key);
            //    Noeud secondNode = createNoeud(dico[dico.Last().Key], null, null, dico.Last().Key);
            //    dico.Remove(dico.Last().Key);

            //    double addition = firstNode.Proba + secondNode.Proba;
            //    //Création de connexion
            //    connexion = createNoeud(addition, &firstNode, &secondNode);

            //    if (dico.ContainsKey('\0')) {
            //        addition = tree.Proba + connexion.Proba;
            //        temp = createNoeud(addition, &tree, &connexion);
            //        tree = temp;
            //        dico.Remove('\0');
            //    } else {
            //        tree = connexion;
            //    }

            //    dico.Add('\0', addition);

            //}
            return tree;
        }

        unsafe static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrez le nom du fichier à analyser");
            string fichier = "./TheSonnets.txt";//Console.ReadLine();

            string text = LireFichier(fichier);
            int longueurText = text.Length;
            Dictionary<char, double> dico = CreateDico(text);

            AffichageDico(dico);

            double entropie = EntropieCalcul(dico, longueurText);
            double redondance = Math.Log(dico.Count, 2) - entropie;

            Console.WriteLine("\nRedondance (R=D-H) : " + redondance);
            Console.WriteLine("Entropie : " + entropie.ToString());


            Noeud node = CreateTree(dico);
            Console.WriteLine(node.Proba);
            //TreeContent[] myTab = CreateTree(dico);

            //foreach (var item in myTab)
            //{
            //    Console.WriteLine("Key : " + item.Key + " Proba : " + item.Proba);
            //}

            Console.ReadKey();

        }

    }
}