﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApi1.Models;

namespace WepApi1.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas= repo.Retrieve();
            //List<ApuestaDTO> apuestas = repo.RetrieveDTO();

            return apuestas;

        }
        // GET: api/Apuestas?Email_Usuario=usuario & Id_Mercado=id
        public IEnumerable<Apuesta> Get(string usuario , int id)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas= repo.RetrieveByUsuarioandId_mercado(usuario,id);
            return apuestas;

        }
        // GET: api/Apuestas?Id_Mercado=id & Email_Usuario=usuario
        [Authorize(Roles = "Admin")]
        public IEnumerable<Apuesta> GetEmail(string user,int id)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.RetrieveById_mercadoandEmail_Usuario(user,id);
            return apuestas;

        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            return null;
        }

        // POST: api/Apuestas
        [Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);

        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
