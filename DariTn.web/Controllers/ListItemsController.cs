using DariTn.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DariTn.web.Controllers
{
    public class ListItemsController : ApiController
    {
    
        private static List<MeubleVM> Meublevms { get; set; } = new List<MeubleVM>();

        // GET api/<controller>
        public IEnumerable<MeubleVM> Get()
        {
            return Meublevms;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var item = Meublevms.FirstOrDefault(x => x.IdMeuble == id);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]MeubleVM model)
        {
            if (string.IsNullOrEmpty(model?.Titre))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if (Meublevms.Count > 0)
            {
                maxId = Meublevms.Max(x => x.IdMeuble);
            }
            model.IdMeuble = maxId + 1;
            Meublevms.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]MeubleVM model)
        {
            if (string.IsNullOrEmpty(model?.Titre))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var item = Meublevms.FirstOrDefault(x => x.IdMeuble == id);
            if (item != null)
            {
                // Update *all* of the item's properties
                item.Titre = model.Titre;

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var item = Meublevms.FirstOrDefault(x => x.IdMeuble == id);
            if (item != null)
            {
                Meublevms.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}