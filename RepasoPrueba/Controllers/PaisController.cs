using RepasoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepasoPrueba.Controllers
{
    public class PaisController : ApiController
    {
        private Datos data;
        public PaisController()
        {
           
            this.data = new Datos();
        }

        public IEnumerable<Pais> GetPaises()
        {
            return data.GetPaises();
        }

        // Ruta URL: "POST(Insert): api/categories"
        public int PostPais([FromBody] Pais pais)
        {
            // Llamar a la Capa de Acceso a Datos
            return data.InsertPais(pais);
        }

        // Ruta URL: "PUT(Update): api/categories/masks"
        public int PutCategory(string id, [FromBody] Pais pais)
        {
            pais.IdPais = id;
            // Llamar a la Capa de Acceso a Datos
            return data.UpdatePais(pais);
        }

        public int DeleteCategory(string id)
        {
            Pais pais = new Pais();
            pais.IdPais = id;
            // Llamar a la Capa de Acceso a Datos
            return data.DeletePais(pais);
        }

    }
}
