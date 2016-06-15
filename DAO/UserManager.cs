using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserManager
    {
        public static void InitializeListUser(IList<UserAccount> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string path = dirInfo.FullName + "\\DAO\\XMLSaveUser\\ListUserSave.xml";
            ListUserXMLManager.ReadListUserInXMLFile(list, path);
        }

        public static void SaveListUser(IList<UserAccount> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string path = dirInfo.FullName + "\\DAO\\XMLSaveUser\\ListUserSave.xml";
            ListUserXMLManager.WriteListuserInXMLFile(list, path);
        }
    }
}
