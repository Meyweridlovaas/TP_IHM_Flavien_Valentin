using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO
{
    public static class ListAnimalXMLManager
    {
        public static void ReadListAnimalInXMLFile(IList<Animal> list, string path)
        {
            XDocument file = XDocument.Load(path);
            List<Animal> listAnimal;
            listAnimal = file.Descendants("Animal")
                        .Select(eltAnimal => new Animal()
                        {
                            Name = eltAnimal.Element("Name").Value,
                            Family = eltAnimal.Element("Family").Value,
                            Description = eltAnimal.Element("Description").Value,
                            ImageSource = eltAnimal.Element("ImageSource").Value
                        }).ToList();
            foreach (var animal in listAnimal)
            {
                list.Add(animal);
            }
        }

        public static void WriteListAnimalInXMLFile(IList<Animal> list, string path)
        {
            XDocument file = new XDocument();
            var listElement = list.Select(animal => new XElement("Animal",
                                                        new XElement("Name", animal.Name),
                                                        new XElement("Family", animal.Family),
                                                        new XElement("Description", animal.Description),
                                                        new XElement("ImageSource", animal.ImageSource)));
            file.Add(new XElement("ListAnimal", listElement));
            file.Save(path);
        }
    }
}
