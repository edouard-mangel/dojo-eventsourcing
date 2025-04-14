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

    private static AmpouleEvent Decide(Ampoule ampoule, AmpouleCommand command)
    {
        AmpouleEvent evenement;
        switch (command)
        {
            case AmpouleCommand.SwitchOff:
                if (!ampoule.EstAllume || ampoule.NbUtilisationsRestantes == 0)
                    evenement = AmpouleEvent.None;
                else
                {
                    evenement = AmpouleEvent.Eteindre;
                }
                break;
            case AmpouleCommand.SwitchOn:
                if (ampoule.EstAllume || ampoule.NbUtilisationsRestantes == 0)
                {
                    evenement = AmpouleEvent.None;
                } else if (ampoule.NbUtilisationsRestantes <= 1)
                {
                    evenement = AmpouleEvent.Claquer;
                } else
                {
                    evenement = AmpouleEvent.Allumer;
                }
                break;
            default:
                evenement = AmpouleEvent.None;
                break;
        }
        return evenement; 
    
    }

    public static Ampoule Evolve(Ampoule ampoule, AmpouleEvent evenement)
    { 
        switch (evenement)
        {
            case AmpouleEvent.Allumer:
                return new Ampoule(ampoule.Id, ampoule.NbUtilisationsRestantes - 1, true);
            case AmpouleEvent.Eteindre:
                return new Ampoule(ampoule.Id, ampoule.NbUtilisationsRestantes, false);
            case AmpouleEvent.Claquer:
                Console.WriteLine("L'ampoule a claqué.");
                return new Ampoule(ampoule.Id, 0, false);
            case AmpouleEvent.None:
            default:
                return ampoule;
        }
    }

    public Ampoule Allumer()
    {
        return Ampoule.Evolve(this, Decide(this, AmpouleCommand.SwitchOn));        
    }

    public Ampoule Eteindre()
    {
        return Ampoule.Evolve(this, Decide(this, AmpouleCommand.SwitchOff));
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
