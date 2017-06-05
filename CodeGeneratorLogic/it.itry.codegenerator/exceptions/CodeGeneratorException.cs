using System;
using System.Collections.Generic;
using System.Text;

namespace it.itry.codegenerator.exceptions
{
    class CodeGeneratorException : Exception
    {
        public CodeGeneratorException() { }

        public CodeGeneratorException(string e)
            : base(e)
        {
            
        }

        public CodeGeneratorException(string e, Exception inner)
            :
            base(e, inner)
        {
            
        }
    }
}
