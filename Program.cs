using System;
using System.Collections.Generic;
using System.IO;

namespace GestionnaireCompteBancaire
{
    /// <summary>
    /// Exercice d'application du cours "Apprendre à programmer en C#" sur OpenClassrooms
    /// Application de gestion de comptes bancaires (courant et épargne) des clients d'une banque
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client("Jane Doe", "0987654");
            IList<string> listeDesTransactions = new List<string>();
            string choixMenu = "";

            string infosClient = client.AfficherInformations();
            double depot = 0;
            double retrait = 0;
            string entreeDepotCourant = "";
            string entreeDepotEpargne = "";
            string entreeRetraitCourant = "";
            string entreeRetraitEpargne = "";
            listeDesTransactions.Add(infosClient);

            do
            {
                //Mettre à jour la liste des transactions lors d'un dépôt
                if (depot > 0)
                {
                    if (choixMenu.ToUpper() == "CD")
                    {
                        entreeDepotCourant = ("Transaction : Dépôt de " + depot + "$ sur le compte courant à " + DateTime.Now.ToString() + ". Solde actuel : " + client.SoldeCourant + "$");
                        listeDesTransactions.Add(entreeDepotCourant);
                    }
                    if (choixMenu.ToUpper() == "ED")
                    {
                        entreeDepotEpargne = ("Transaction : Dépôt de " + depot + "$ sur le compte épargne à " + DateTime.Now.ToString() + ". Solde actuel : " + client.SoldeEpargne + "$");
                        listeDesTransactions.Add(entreeDepotEpargne);
                    }
                    depot = 0;
                }

                ////Mettre à jour la liste des transactions lors d'un retrait
                if (retrait > 0)
                {
                    if (choixMenu.ToUpper() == "CR")
                    {
                        entreeRetraitCourant = ("Transaction : Retrait de " + retrait + "$ du compte courant à " + DateTime.Now.ToString() + ". Solde actuel : " + client.SoldeCourant + "$");
                        listeDesTransactions.Add(entreeRetraitCourant);
                    }
                    if (choixMenu.ToUpper() == "ER")
                    {
                        entreeRetraitEpargne = ("Transaction : Retrait de " + retrait + "$ du compte épargne à " + DateTime.Now.ToString() + ". Solde actuel : " + client.SoldeEpargne + "$");
                        listeDesTransactions.Add(entreeRetraitEpargne);
                    }
                    retrait = 0;
                }

                // Afficher le menu
                Menu();
                // Choisir une des options
                choixMenu = Console.ReadLine();

                switch (choixMenu.ToUpper())
                {
                    case "I":  // Voir les informations sur le titulaire du compte
                        Console.WriteLine(client.AfficherInformations());
                        break;
                    case "CS":  // Consulter le solde courant
                        client.AfficherSoldeCourant();
                        break;
                    case "CD":  // Effectuer un dépôt sur le compte courant
                        depot = client.DepotCompte(choixMenu.ToUpper());
                        break;
                    case "CR":  // Effectuer un retrait sur le compte courant
                        retrait = client.RetraitCompte(choixMenu.ToUpper());
                        break;
                    case "ES":  // Consulter le solde épargne
                        client.AfficherSoldeEpargne();
                        break;
                    case "ED":  // Effectuer un dépôt sur le compte épargne
                        depot = client.DepotCompte(choixMenu.ToUpper());
                        break;
                    case "ER":  // Effectuer un retrait sur le compte épargne
                        retrait = client.RetraitCompte(choixMenu.ToUpper());
                        break;
                    case "X":  // Quitter
                        Console.Clear();
                        EcrireFichier(listeDesTransactions, "transactions");
                        Console.WriteLine("Merci et à bientôt !");
                        //Environment.Exit(0);
                        break;
                }
            } while (choixMenu.ToUpper() != "X");

        }

        // Afficher le menu
        public static void Menu()
        {
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
            Console.WriteLine("[I] Afficher les informations sur le titulaire du compte");
            Console.WriteLine("[CS] Compte courant - Consulter le solde");
            Console.WriteLine("[CD] Compte courant - Déposer des fonds");
            Console.WriteLine("[CR] Compte courant - Retirer des fonds");
            Console.WriteLine("[ES] Compte épargne - Consulter le solde");
            Console.WriteLine("ED[] Compte épargne - Déposer des fonds");
            Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
            Console.WriteLine("[X] Quitter");
        }

        // Écrire toutes les transactions du compte courant et du compte épargne dans un fichier texte
        public static void EcrireFichier(IList<string> transactions, string nomFichier)
        {
            try
            {
                using (StreamWriter resume = new StreamWriter(nomFichier + ".txt", true))
                {
                    foreach (string transaction in transactions)
                    {
                        resume.WriteLine(transaction);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Impossible d'écrire dans le fichier " + nomFichier + e.ToString());
            }
        }
    }
}
