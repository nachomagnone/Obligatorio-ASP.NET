using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class AvisoDestacado : Aviso
    {
        private Articulo articulo;

        public Articulo Articulo
        {
            get { return articulo; }
            set { articulo = value;}
        }

        public AvisoDestacado(int pNumero, DateTime pFecha, Categoria pCategoria, List<string> pTelefonos, Articulo pArticulo)
            : base(pNumero, pFecha, pCategoria, pTelefonos)
        {
            Articulo = pArticulo;
        }

        public override string ToString()
        {
            return "\n\tAviso Destacado: " + base.ToString() + "\n\tArticulo: " + Articulo.ToString() + "\n";
        }
    }
}
