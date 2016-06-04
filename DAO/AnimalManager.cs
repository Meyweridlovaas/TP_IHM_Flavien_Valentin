using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AnimalManager
    {
        /// <summary>
        /// Initialise une liste d'animaux
        /// </summary>
        public static void InitializeListAnimal(IList<Animal> list)
        {
            list.Add(new Animal
            {
                Name = "Chat",
                Family = "Animal",
                Description = "Fait le buzz sur internet",
                ImageSource = "http://media.virginradio.fr/article-2505914-fb-f1415609183/chat-mignon-petit-chaton-therapie-detente.jpg"
            });
            list.Add(new Animal
            {
                Name = "Poisson rouge",
                Family = "Poisson",
                Description = "bloup bloup bloup bloup bloup bloup bloup bloup bloup bloup bloup bloup",
                ImageSource = "http://i.telegraph.co.uk/multimedia/archive/01396/fish_1396516c.jpg"
            });
        }
    }
}
