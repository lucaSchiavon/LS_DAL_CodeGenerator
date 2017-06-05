using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.factory
{
    public class CodeFileFactory
    {
        #region PROPERTIES
        #endregion
        private CodeFileFactory() { }
        public static it.itry.codegenerator.classes.baseclass.GenericFile getCodeFile(it.itry.codegenerator.enums.enTipoFile tipoFile, it.itry.codegenerator.classes.baseclass.Database database)
        {
            it.itry.codegenerator.classes.baseclass.GenericFile genFile=null;
            switch (tipoFile)
            {
                case it.itry.codegenerator.enums.enTipoFile.CSHARP:
                    genFile = new it.itry.codegenerator.classes.CSharpFile();
                    break;
                case it.itry.codegenerator.enums.enTipoFile.VB:
                    genFile = new it.itry.codegenerator.classes.VBFile();
                    break;
                default:
                    return null;
            }
            genFile.DataBase = database;
            return genFile;
        }

    }
}
