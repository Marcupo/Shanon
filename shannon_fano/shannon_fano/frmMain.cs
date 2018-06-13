﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace shannon_fano
{
    public partial class frmMain : Form
    {

        public struct Element
        {
            public char Lettre;
            public double Proba;
            public string Code;
        }

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

        public static Dictionary<char, double> TriDico(Dictionary<char, double> dico)
        {
            var sortedList = from pair in dico orderby pair.Value ascending select pair;
            Dictionary<char, double> dicoTrier = new Dictionary<char, double>();
            foreach (KeyValuePair<char, double> lettre in sortedList)
            {
                dicoTrier.Add(lettre.Key, lettre.Value);
            }

            return dicoTrier;
        }

        public static List<Element> FillList(Dictionary<char, double> dico)
        {
            List<Element> nList = new List<Element>();
            Element temp = new Element
            {
                Code = ""
            };
            foreach (char lettre in dico.Keys)
            {
                temp.Lettre = lettre;
                temp.Proba = dico[lettre];
                nList.Add(temp);
            }
            return nList;
        }

        static List<Element> Encoder(List<Element> list_encode, float MaxTaux)
        {
            double cpt = 0;
            int idxStart = 0;
            List<Element> listTraitement = new List<Element>();
            Element temp;
            //  Si la liste est plus petit que 2
            if (list_encode.Count <= 2)
            {
                if (list_encode.Count == 2)
                {
                    temp = list_encode[0];
                    temp.Code += "1";
                    list_encode[0] = temp;

                    temp = list_encode[1];
                    temp.Code += "0";
                    list_encode[1] = temp;
                }
            }
            else
            {
                //  Partie du haut
                for (int i = 0; i < list_encode.Count; i++)
                {
                    idxStart = i;
                    if ((cpt < MaxTaux) && (i + 1 != list_encode.Count))
                    {
                        cpt += list_encode[i].Proba;
                        temp = list_encode[i];
                        temp.Code += "1";
                        list_encode[i] = temp;
                        listTraitement.Add(list_encode[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                listTraitement = Encoder(listTraitement, MaxTaux / 2);
                for (int i = 0; i < idxStart; i++)
                {
                    temp = listTraitement[i];
                    list_encode[i] = temp;
                }
                listTraitement.Clear();
                //  Partie du bas
                for (int i = idxStart; i < list_encode.Count; i++)
                {
                    temp = list_encode[i];
                    temp.Code += "0";
                    list_encode[i] = temp;
                    listTraitement.Add(list_encode[i]);
                }
                listTraitement = Encoder(listTraitement, MaxTaux / 2);
                for (int i = idxStart; i < list_encode.Count; i++)
                {
                    temp = listTraitement[i - idxStart];
                    list_encode[i] = temp;

                }
            }
            return list_encode;
        }

        public static byte[] GetBytes(string bitString)
        {
            byte[] output = new byte[bitString.Length / 8];

            for (int i = 0; i < output.Length; i++)
            {
                for (int b = 0; b <= 7; b++)
                {
                    output[i] |= (byte)((bitString[i * 8 + b] == '1' ? 1 : 0) << (7 - b));
                }
            }

            return output;
        }

        public static void WriteFile(List<Element> list_encode, string nomFichier, string text)
        {
            FileStream fs = new FileStream(nomFichier, FileMode.Create);
            Dictionary<Char, string> dico = new Dictionary<char, string>();
            string tmp = "";
            foreach (Element element in list_encode)
            {
                dico.Add(element.Lettre, element.Code);
            }
            foreach (char lettre in text)
            {
                foreach (char code in dico[lettre])
                {
                    tmp += code;
                    if (tmp.Length == 8)
                        fs.WriteByte(GetBytes(tmp)[0]);
                }
            }
            fs.Close();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnEncoder_Click(object sender, EventArgs e)
        {
            string fichier = tbxSource.Text;
            string text = LireFichier(fichier);
            string affichage = string.Empty;
            double entropie, redondance, longeur = 0;

            Dictionary<char, double> dico = CreateDico(text);

            dico = TriDico(dico);

            entropie = EntropieCalcul(dico, text.Length);
            redondance = Math.Log(dico.Count, 2) - entropie;

            lblEntropie.Text = "Entropie : " + entropie.ToString();
            lblRedondance.Text = "Redondance (R=D-H) : " + redondance;

            List<Element> myList = new List<Element>();

            myList = FillList(dico);
            myList = Encoder(myList, 0.5f);
            myList.Reverse();

            for (int i = 0; i < myList.Count; i++)
            {
                affichage += "Lettre : " + myList[i].Lettre + " Proba : ";
                affichage += String.Format("{0:0.00000}", myList[i].Proba);
                affichage += " code : " + myList[i].Code + Environment.NewLine;
                longeur += myList[i].Code.Length * (myList[i].Proba * text.Length);
            }

            Console.WriteLine("Notre longueur  : " + longeur);
            Console.WriteLine("Longueur normal : " + text.Length * 8);
            lblBitsAvant.Text = (text.Length * 8).ToString() + " bits";
            lblBitsApres.Text = longeur.ToString() + " bits";
            tbxAffichage.Text = affichage;
        }
    }
}
