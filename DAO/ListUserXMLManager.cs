using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO
{
    class ListUserXMLManager
    {
        public static void ReadListUserInXMLFile(IList<UserAccount> list, string path)
        {
            XDocument file = XDocument.Load(path);
            List<UserAccount> listUser;
            listUser = file.Descendants("User")
                        .Select(eltUser => new UserAccount()
                        {
                            Name = eltUser.Element("Name").Value,
                            ListAnimalSource = eltUser.Element("ListAnimalSource").Value,
                            Password = UserAccount.DecryptPassword(eltUser.Element("Password").Value)
                        }).ToList();
            foreach (var user in listUser)
            {
                list.Add(user);
            }
        }

        public static void WriteListuserInXMLFile(IList<UserAccount> list, string path)
        {
            XDocument file = new XDocument();
            var listElement = list.Select(user => new XElement("User",
                                                        new XElement("Name", user.Name),
                                                        new XElement("ListAnimalSource", user.ListAnimalSource),
                                                        new XElement("Password", user.Password)));
            file.Add(new XElement("ListUser", listElement));
            file.Save(path);
        }
    }
}
