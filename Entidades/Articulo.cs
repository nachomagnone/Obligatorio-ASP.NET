using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Articulo
    {
        private string codigo;
        private double precio; 
        private string descripcion;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value == string.Empty || value.Length != 6)
                    throw new Exception("\n\tCodigo alfanumerico, debe ser de 6 caracteres");
                else
                    codigo = value;
            }
        }

        public double Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                    throw new Exception("\n\tDebe Ingresar un Valor y tiene que ser Positivo");
                else
                    precio = value;
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value == string.Empty || value.Length == 0)
                    throw new Exception("\n\tDebe Ingresar una Breve Descripcion");
                else
                    descripcion = value;
            }
        }

        public Articulo(string pCodigo, double pPrecio, string pDescripcion)
        {
            Codigo = pCodigo;
            Precio = pPrecio;
            Descripcion = pDescripcion;
        }

        public override string ToString()
        {
            return "\n\tCodigo: " + Codigo + "\n\tPrecio: " + Precio + "\n\tDescripcion: " + Descripcion + "\n";
        }
    }
}