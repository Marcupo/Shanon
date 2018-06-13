/*
 * Auteur                   : Paschoud Nicolas et Vlajkovic Marco
 * Derniere Modification    : 13.06.2018
 * Version                  : 1.0
 * Projet                   : shannon_fano
 * Description              : Encode / Decode un texte avec la méthode de shannon fano
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public struct Decodage
        {
            public string text;
            public Dictionary<string, char> dico;
        }

        /// <summary>
        /// Lis un fichier
        /// </summary>
        /// <param name="chemin">Chemin vers le fichier</param>
        /// <returns>Un string avec tout le contenu du fichier</returns>
        public static string LireFichier(string chemin)
        {
            return File.ReadAllText(chemin);
        }

        /// <summary>
        /// Permet de crée un dictionnaire a partir d'un string donné
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calcule l'entropie
        /// </summary>
        /// <param name="dico"></param>
        /// <param name="longueurText"></param>
        /// <returns></returns>
        static double EntropieCalcul(Dictionary<char, double> dico, int longueurText)
        {
            double entropie = 0f;
            foreach (double proba in dico.Values)
            {
                entropie += -Math.Log(proba, 2) * proba;
            }
            return entropie;
        }

        /// <summary>
        /// Trie le dictionnaire dans l'ordre ascendant
        /// </summary>
        /// <param name="dico">Le dictionnaire a trier</param>
        /// <returns>Le dictionnaire trié</returns>
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

        /// <summary>
        /// Crée une liste d'element a partir d'un dictionnaire de lettre et de proba
        /// </summary>
        /// <param name="dico">Dictionnaire contenant les lettres et les proba </param>
        /// <returns>Liste remplie avec les Code vide</returns>
        public static List<Element> FillList(Dictionary<char, double> dico)
        {
            List<Element> nList = new List<Element>();
            Element temp = new Element();
            foreach (char lettre in dico.Keys)
            {
                temp.Lettre = lettre;
                temp.Proba = dico[lettre];
                nList.Add(temp);
            }
            return nList;
        }

        /// <summary>
        /// Permet de remplir les champs code de la liste d'element
        /// </summary>
        /// <param name="list_encode">liste a encoder</param>
        /// <param name="MaxTaux">Parametre qui permet de faire de la recursion avec la methode Shannon fano</param>
        /// <returns></returns>
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

        /// <summary>
        /// write_header est utilisée pour écrire l'en-tête du fichier compresser
        /// </summary>
        /// <param name="tw"></param>
        /// <param name="dico"></param>
        public static void WriteHeader(TextWriter tw, Dictionary<char, string> dico)
        {
            foreach (char car in dico.Keys)
            {
                //  Ecriture du caractère, suivis d'un espace puis de son code
                tw.Write(car + " " + dico[car] + " ");
            }
            tw.Write("00000000");
        }

        /// <summary>
        /// Cette fonction permet d'écrire dans un fichier notre texte encodé
        /// </summary>
        /// <param name="list_encode">Notre table d'encodage</param>
        /// <param name="nomFichier">Nom du fichier de destination</param>
        /// <param name="text">Text a encodé</param>
        public static void WriteFile(List<Element> list_encode, string nomFichier, string text)
        {
            Dictionary<Char, string> dico = new Dictionary<char, string>();
            TextWriter tw = new StreamWriter(nomFichier);

            foreach (Element element in list_encode)
            {
                dico.Add(element.Lettre, element.Code);
            }

            //  Ecriture de l'en-tête avant le reste du fichier
            WriteHeader(tw, dico);

            foreach (char lettre in text)
            {
                //  Ecriture du code lié au caractère
                tw.Write(dico[lettre]);
            }
            tw.Close();
        }

        /// <summary>
        /// Lis un fichier et retourne le texte decode et un dictionnaire
        /// </summary>
        /// <param name="nomFichier">Nom du fichier a lire</param>
        /// <returns></returns>
        public static Decodage Decode(string nomFichier)
        {
            TextReader tr = new StreamReader(nomFichier);
            Decodage resultat = new Decodage();
            string tmp = "";

            resultat.dico = new Dictionary<string, char>();

            while (tr.Peek() > -1)
            {
                string code = string.Empty;
                char nChar = (char)tr.Read();
                if (tr.Peek() == '0')
                {
                    for (int i = 0; i < 7; i++)
                        tr.Read();
                    break;
                }
                tr.Read();
                while (tr.Peek() != ' ')
                {
                    code += (char)tr.Read();
                }
                resultat.dico.Add(code, nChar);
                tr.Read();
            }
            while (tr.Peek() > -1)
            {
                tmp += (char)tr.Read();

                if (resultat.dico.ContainsKey(tmp))
                {
                    resultat.text += resultat.dico[tmp];
                    tmp = "";
                }
            }
            tr.Close();
            return resultat;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function principale qui permet d'encoder un fichier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEncoder_Click(object sender, EventArgs e)
        {
            //  Verification si le fichier existe
            if (File.Exists(tbxSource.Text))
            {
                //  Initialisation
                string fichier = tbxSource.Text;
                string destination = tbxDestination.Text;
                string text = LireFichier(fichier);
                string affichage = string.Empty;
                double entropie, redondance, longeur = 0;

                //  Lecture tu fichier pour le mettre dans un dictionnaire (lettre,proba)
                Dictionary<char, double> dico_proba = CreateDico(text);

                //  Tri les elements du dictionnaire
                dico_proba = TriDico(dico_proba);

                //  Calcule L'entropie et la redondance
                entropie = EntropieCalcul(dico_proba, text.Length);
                redondance = Math.Log(dico_proba.Count, 2) - entropie;

                //  Crée la table d'encodage
                List<Element> myList = new List<Element>();
                myList = FillList(dico_proba);
                myList = Encoder(myList, 0.5f);
                myList.Reverse();

                //  Création du texte à afficher dans la textbox
                for (int i = 0; i < myList.Count; i++)
                {
                    affichage += "Lettre : " + myList[i].Lettre + " Proba : ";
                    affichage += String.Format("{0:0.00000}", myList[i].Proba);
                    affichage += " Code : " + myList[i].Code + Environment.NewLine;
                    longeur += myList[i].Code.Length * (myList[i].Proba * text.Length);
                }

                //  Affichage
                lblEntropie.Text = "Entropie : " + String.Format("{0:0.00000}", entropie);
                lblRedondance.Text = "Redondance (R=D-H) : " + String.Format("{0:0.00000}", redondance);
                lblBitsAvant.Text = (text.Length * 8).ToString() + " bits";
                lblBitsApres.Text = longeur.ToString() + " bits";
                tbxAffichage.Text = affichage;
                //  Ecriture dans le fichier
                WriteFile(myList, destination, text);
            }
            else
            {
                tbxAffichage.Text = "Nous n'avons pas pu trouvé votre fichier source veuillez verifiez le chemin \"" + tbxSource.Text + "\"";
            }
        }

        /// <summary>
        /// Function principale qui permet de decoder un fichier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecoder_Click(object sender, EventArgs e)
        {
            //  Initialisation
            string affichage = string.Empty;
            string fichier = tbxSource.Text;
            string fichierDest = tbxDestination.Text;
            string textDecode = "";

            tbxAffichage.Text = "Decodage en cours veuillez patientez...";

            //  Appele la fonction de decodage
            Decodage decode = Decode(fichier);

            //  Ressort les valeurs dans des variables
            textDecode = decode.text;
            Dictionary<string, char> dico = decode.dico;

            //  Création du texte à afficher dans la textbox a partir du dictionnaire
            for (int i = 0; i < dico.Count; i++)
            {
                affichage += "Lettre : " + dico.ElementAt(i).Value;
                affichage += " Code : " + dico.ElementAt(i).Key;
                affichage += Environment.NewLine;
            }
            affichage += "\nVotre texte a été enregistré dans : " + fichierDest;

            //  Si un fichier du meme nom existe le supprime
            if (File.Exists(fichierDest))
                File.Delete(fichierDest);

            //  Ecrit le resultat dans le fichier demandé
            File.WriteAllText(fichierDest, textDecode);

            //  Affichage
            lblEntropie.Text = "Entropie : Calcul Impossible";
            lblRedondance.Text = "Redondance (R=D-H) : Calcul Impossible";
            lblBitsAvant.Text = (textDecode.Length * 8).ToString() + " bits";
            lblBitsApres.Text = "Calcul Impossible";
            tbxAffichage.Text = affichage;
        }
    }
}