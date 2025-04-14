using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkbeforecoding;
internal class Ampoule
{
    public string Id { get; set; }
    public int NbUtilisationsRestantes { get; private set; } = 10;
    
    public Ampoule(string Id, int nbUtilisationsRestantes, bool estAllume )
    {
        this.Id = Id;
        NbUtilisationsRestantes = nbUtilisationsRestantes;
        EstAllume = estAllume;
    }

    public bool EstAllume { get; set; } = false;
    public Ampoule Allumer()
    {
        AmpouleEvent evenement ;

        if (EstAllume || NbUtilisationsRestantes == 0)
        {
            evenement = AmpouleEvent.None;
        } else if (NbUtilisationsRestantes <= 1)
        {
            evenement = AmpouleEvent.Claquer;
        } else
        {
            evenement = AmpouleEvent.Allumer;
        }

        switch (evenement)
        {
            
            case AmpouleEvent.Allumer:
                return new Ampoule(this.Id, this.NbUtilisationsRestantes - 1, true);
            case AmpouleEvent.Eteindre:
                return new Ampoule(this.Id, this.NbUtilisationsRestantes, false);
            case AmpouleEvent.Claquer:
                Console.WriteLine("L'ampoule a claqué.");
                return new Ampoule(this.Id, 0, false);
            case AmpouleEvent.None:
            default:
                return this;
        }
    }

    public Ampoule Eteindre()
    {
        if (EstAllume)
        {
            return new Ampoule(this.Id, this.NbUtilisationsRestantes, false);
        }   
        return this; 
    }

    public void SauvegarderSurDisque()
    {
        // Ecrire l'état de l'ampoule dans un fichier 
        string filePath = "ampoule.txt";

        // Création d'une instance de StreamWriter
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Écriture de texte dans le fichier
            writer.WriteLine(this.NbUtilisationsRestantes.ToString() + ' ' + this.EstAllume.ToString());
        }

        Console.WriteLine("Écriture dans le fichier terminée.");
    }

}
