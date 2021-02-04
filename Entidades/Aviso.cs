using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public abstract class Aviso
    {
        //Atributos
        private int numero;
        private DateTime fecha;
        private Categoria categoria;
        private List<string> telefonos = new List<string>();

        //Propiedades
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Categoria Categoria
        {
            get { return categoria; }
            set
            {
                if (value == null)
                    throw new Exception("Se necesita una categoria para el aviso");
                else
                    categoria = value;
            }
        }

        public List<string> Telefonos
        {
            get { return telefonos; }
            set
            {
                if (value == null)
                {
                    throw new Exception("\n\tDebe tener al menos un Telefono");

                }
                else if (((List<string>)value).Count == 0)
                {
                    throw new Exception("No hay teléfonos");
                }
                else
                {
                    telefonos = value;
                }
                
            }
        }

        //Constructor
        public Aviso(int pNumero, DateTime pFecha, Categoria pCategoria, List<string> pTelefonos)
        {
            Numero = pNumero;
            Fecha = pFecha;
            Categoria = pCategoria;
            Telefonos = pTelefonos;
        }

        //operacion
        public override string ToString()
        {
          return "\n\tNumero: " + Numero + "\n\tFecha: " + Fecha + "\n\tCategoria" + Categoria + /*"\n\tTelefono: " + Telefonos +*/ "\n";
        }
    }
}
