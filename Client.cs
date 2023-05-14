using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireCompteBancaire
{
    //Classe Client
    class Client
    {
        // Variables
        private string nom;
        private string numeroCompte;
        double soldeCourant;
        double soldeEpargne;

        //Constructeur
        public Client(string nom, string numeroCompte)
        {
            this.nom = nom;
            this.numeroCompte = numeroCompte;
            this.soldeCourant = 0.0;
            this.soldeEpargne = 0.0;
        }

        //Accesseurs et mutateurs
        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public string NumeroCompte
        {
            get
            {
                return this.numeroCompte;
            }
            set
            {
                this.numeroCompte = value;
            }
        }

        public double SoldeCourant
        {
            get
            {
                return this.soldeCourant;
            }
            set
            {
                this.soldeCourant = value;
            }
        }

        public double SoldeEpargne
        {
            get
            {
                return this.soldeEpargne;
            }
            set
            {
                this.soldeEpargne = value;
            }
        }

        //Méthodes
        // Afficher les informations du compte client
        public string AfficherInformations()
        {
            string informations = ("Nom du client: " + this.Nom + "\nNuméro de compte : " + this.NumeroCompte);
            //Console.WriteLine("Nom du client : " + this.Nom);
            //Console.WriteLine("Numéro de compte : " + this.NumeroCompte);
            return informations;
        }

        // Afficher le solde du compte courant
        public void AfficherSoldeCourant()
        {
            Console.WriteLine("Solde du compte courant : " + this.SoldeCourant + "$");
        }

        // Afficher le solde du compte épargne
        public void AfficherSoldeEpargne()
        {
            Console.WriteLine("Solde du compte épargne : " + this.SoldeEpargne + "$");
        }

        // Faire un dépôt sur le compte client quelque soit le type
        public double DepotCompte(string typeCompte)
        {
            Console.WriteLine("Quel montant souhaitez-vous déposer ?");
            double depot = Double.Parse(Console.ReadLine());

            if (typeCompte == "CD")
            {
                this.SoldeCourant += depot;
            }
            if (typeCompte == "ED")
            {
                this.SoldeEpargne += depot;
            }

            Console.WriteLine("Vous avez déposé : " + depot + "$");
            return depot;
        }

        // Faire un retrait sur le compte client quelque soit le type
        public double RetraitCompte(string typeCompte)
        {
            Console.WriteLine("Quel montant souhaitez-vous retirer ?");
            double retrait = Double.Parse(Console.ReadLine());

            if (typeCompte == "CD")
            {
                this.SoldeCourant -= retrait;
            }
            if (typeCompte == "ED")
            {
                this.SoldeEpargne -= retrait;
            }

            Console.WriteLine("Vous avez retiré : " + retrait + "$");
            return retrait;
        }
    }
}
