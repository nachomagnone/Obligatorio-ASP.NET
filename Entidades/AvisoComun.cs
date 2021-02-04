using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class AvisoComun : Aviso
    {
        private List<string> palabrasClaves = new List<string>();

        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
            set {
                if (value == null)
                    throw new Exception("\n\tDebe tener al menos una Palabra Clave");
                else
                palabrasClaves = value; 
            }
        }

        public AvisoComun(int pNumero, DateTime pFecha, Categoria pCategoria, List<string> pTelefono, List<string> pPalabras)
            : base(pNumero, pFecha, pCategoria, pTelefono)
        {
           PalabrasClaves = pPalabras;
        }

        //Chequear esta parte que no estoy seguro
        public override string ToString()
        {
            return ("\n\tAviso Común: " + " " + base.ToString() + /*"\n\tPalabras: " + palabrasClaves.ToString() +*/ "\n"); 
        }
        
    }
}
