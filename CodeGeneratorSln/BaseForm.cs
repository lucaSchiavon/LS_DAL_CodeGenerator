using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
    public class BaseForm : System.Windows.Forms.Form
    {

        protected void setError(string msg)
        {
            MessageBox.Show(msg,"Errore",  MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }

    
}
