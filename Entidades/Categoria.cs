using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class Categoria
    {
       //Atributos
        private string codigo;
        private string nombre;
        private double precioBase; 

       //Propiedades
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value == string.Empty || value.Length != 3)
                    throw new Exception("\n\tEl Codigo interno debe tener tres caracteres");
                else
                    codigo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == string.Empty || value.Length == 0)
                    throw new Exception("\n\tEl Nombre no puede estar vacio");
                else
                    nombre = value;
            }
        }
    
        public double PrecioBase
        {
            get { return precioBase; }
            set
            {
                if (value <= 0)
                    throw new Exception("\n\tEl Precio debe ser Positivo");
                else
                    precioBase = value;
            }
        }

        //Constructor
        public Categoria(string pCodigo, string pNombre, double  pPrecio)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            PrecioBase = pPrecio;
        }

        //Operacion
        public override string ToString()
        {
            return "\n\tCodigo: " + Codigo + "\n\tNombre: " + Nombre + "\n\tPrecio: " + PrecioBase + "\n";
        }
    }
}
