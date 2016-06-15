// ========================================================================
//
// Module        : AnimalManager.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class AnimalManager
    {
        /// <summary>
        /// Initialise une liste d'animaux
        /// </summary>
        public static void InitializeListAnimal(IList<Animal> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string path = dirInfo.FullName + "\\DAO\\XMLStub\\ListAnimalDefault.xml";
            ListAnimalXMLManager.ReadListAnimalInXMLFile(list, path);
        }
    }
}
