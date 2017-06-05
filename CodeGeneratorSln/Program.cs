using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CodeGenerator
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CodeGenerator.CodeGeneratorForm());
            //Application.Run(new CodeGeneratorSln.testForm());
        }
    }
}