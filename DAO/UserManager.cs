// ========================================================================
//
// Module        : UserManager.cs
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
    public class UserManager
    {
        /// <summary>
        /// Charge les utilisateurs
        /// </summary>
        public static void InitializeListUser(IList<UserAccount> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string path = dirInfo.FullName + "\\DAO\\XMLSaveUser\\ListUserSave.xml";
            ListUserXMLManager.ReadListUserInXMLFile(list, path);
        }

        /// <summary>
        /// Sauvegarde les utilisateurs
        /// </summary>
        public static void SaveListUser(IList<UserAccount> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string path = dirInfo.FullName + "\\DAO\\XMLSaveUser\\ListUserSave.xml";
            ListUserXMLManager.WriteListuserInXMLFile(list, path);
        }
    }
}
