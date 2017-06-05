using System;
using System.Collections.Generic;
using System.Text;

namespace it.itry.codegenerator.classes.baseclass
{
    public abstract class GenericFile
    {
        private it.itry.codegenerator.classes.baseclass.Database m_DataBase;
        public it.itry.codegenerator.classes.baseclass.Database DataBase { get { return m_DataBase; } set { m_DataBase = value; } }

        /// <summary>
        /// Custom NameSpace
        /// </summary>
        private string m_customNamespace;
        public string CustomNamespace {get {return m_customNamespace;}set { m_customNamespace = value;}}
        /// <summary>
        /// Percorso dove creare la cartella coi sorgenti
        /// </summary>
        private string m_path;
        public string Path { get { return m_path; } set { m_path = value; } }

        public abstract void doCreateFile(System.Data.DataTable dtSchema,string customTableName, System.Collections.Specialized.StringCollection list);

        public abstract void doCreateManager(System.Collections.Specialized.StringCollection list, bool useSingleTonPattern);
        /// <summary>
        /// Data una stringa la ritorna formattata secondo lo stile CamelCase.
        /// </summary>
        /// <param name="str">stringa da rendere in formato CamelCase</param>
        /// <returns>System.String</returns>
        protected string setUpperCamelCase(string str, bool addPrefix)
        {
            if (str.Length < 1) return str;
            if (str.Length == 1) return str.ToUpper();
            str = str.ToLower();
            str = str.TrimStart();
            str = str.TrimEnd();
            string tempStr = "";
            bool makeUpper = false;
            tempStr = str.Substring(0, 1).ToUpper();
            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]))
                {
                    //non è una lettera, memorizzo che tipo di carattere è
                    char carattere = str[i];
                    //scrivilo in maiuscolo
                    makeUpper = true;
                    if (char.IsWhiteSpace(str[i])) continue;
                    if (str[i] == '_') continue;
                    tempStr += carattere.ToString();
                }
                else
                {
                    if (makeUpper)
                    {
                        tempStr += str[i].ToString().ToUpper();
                        makeUpper = false;
                    }
                    else
                    {
                        tempStr += str[i].ToString();
                    }

                }
            }
            return (!addPrefix) ? tempStr : "m_"+tempStr;
        }

        public void doCreateMainDirectory()
        {
            if (!System.IO.Directory.Exists(Utils.getCodeGeneratorDirName()))
            {
                System.IO.Directory.CreateDirectory(Utils.getCodeGeneratorDirName());
            }
        }

        public string getDirManagers()
        {
            return (string.IsNullOrEmpty(m_path) ? string.Empty : m_path + "\\") + Utils.getCodeGeneratorDirName() + "\\managers";
        }
        public string getDirClasses()
        {
            return (string.IsNullOrEmpty(m_path) ? string.Empty : m_path + "\\") + Utils.getCodeGeneratorDirName() + "\\classes";
        }
    }
}
