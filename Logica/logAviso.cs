using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;
using Persistencia;

namespace Logica
{
    public class logAviso
    {
        private perAviso persistencia = new perAviso();

        public void AgregarCom(AvisoComun avisoComun)
        {
            int valor = persistencia.AgregarComun(avisoComun);
            if (valor <= 0)
                throw new Exception("Error al ingresar el Aviso Comun");

            avisoComun.Numero = valor;

            foreach (string telefono in avisoComun.Telefonos)
            {
                persistencia.AgregarTelefono(avisoComun.Numero, telefono);
            }

            foreach (string palabra in avisoComun.PalabrasClaves)
            {
                persistencia.AgregarPalabrasClaves(avisoComun.Numero, palabra);
            }

        }

        public void AgregarTel(AvisoComun avisoComun)
        {
            int valor = persistencia.AgregarComun(avisoComun);
            if (valor <= 0)
                throw new Exception("Error al ingresar el Telefono");
        }

        public void AgregarPalabras(AvisoComun avisoComun)
        {
            int valor = persistencia.AgregarComun(avisoComun);
            if (valor <= 0)
                throw new Exception("Error al ingresar Palabras Claves");
        }

        public void AgregarDesta(AvisoDestacado avisoDestacado)
        {
            int valor = persistencia.AgregarDestacado(avisoDestacado);
            if (valor <= 0)
            {
                throw new Exception("Error al ingresar Aviso Destacado  " + valor);
            }

            avisoDestacado.Numero = valor;

            foreach (string telefonos in avisoDestacado.Telefonos)
            {
                persistencia.AgregarTelefono(avisoDestacado.Numero, telefonos);
            }
        }

        public List<Aviso> Listar(string CodigoCategoria)
        {
            List<Aviso> listar = new List<Aviso>();
            listar.AddRange(persistencia.ListarComunesporCategoria(CodigoCategoria));
            listar.AddRange(persistencia.ListarDestacadosporCategoria(CodigoCategoria));

            return listar;
        }

        public List<Aviso> ListadoAvisos()
        {
            List<Aviso> listadoAvisos = new List<Aviso>();
            listadoAvisos.AddRange(persistencia.ListarAvisosComunes());
            listadoAvisos.AddRange(persistencia.ListarAvisosDestacados());

            return listadoAvisos;
       }

        public List<AvisoComun> ListarAvisosComunes()
        {
            return persistencia.ListarAvisosComunes();
        }

        public List<AvisoDestacado> ListarAvisosDestacados()
        {
            return persistencia.ListarAvisosDestacados();
        }

        public AvisoDestacado BuscarDestacadoPorArticulo(string codigoArticulo)
        {
            return persistencia.BuscarAvisoPorArticulo(codigoArticulo);
        }

        public List<string> ListarTelefonos(int IdAviso)
        {
            return persistencia.ListarTelefonos(IdAviso);
        }

        public List<string> ListarPalabrasClaves(int IdAviso)
        {
            return persistencia.ListarPalabrasClaves(IdAviso);
        }

    }
}
