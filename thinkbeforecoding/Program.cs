namespace thinkbeforecoding
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ampoule, allumer.");
            var ampoule = getAmpoule("ampoule");

            ampoule = ampoule.Eteindre();
            ampoule = ampoule.Eteindre();
            ampoule = ampoule.Allumer();
            ampoule = ampoule.Eteindre();
            ampoule = ampoule.Allumer();
            ampoule.SauvegarderSurDisque();
        }

        private static Ampoule getAmpoule(string id)
        {
            string filePath =  id + ".txt";

            // Création d'une instance de StreamWriter
            using (StreamReader reader = new(filePath))
            {
                // Écriture de texte dans le fichier
                var data = reader.ReadLine().Split(' ');
                return new Ampoule(id, int.Parse(data[0]),bool.Parse( data[1]));
            }
        }
    }
}
