using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaParcial.Models;

namespace PruebaParcial.Controllers
{
    public class GonzalesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Gonzales
        //[Authorize]
        public IQueryable<Gonzales> GetGonzales()
        {
            return db.Gonzales;
        }

        // GET: api/Gonzales/5
        [ResponseType(typeof(Gonzales))]
        public IHttpActionResult GetGonzales(int id)
        {
            Gonzales gonzales = db.Gonzales.Find(id);
            if (gonzales == null)
            {
                return NotFound();
            }

            return Ok(gonzales);
        }

        // PUT: api/Gonzales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGonzales(int id, Gonzales gonzales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gonzales.GonzalesID)
            {
                return BadRequest();
            }

            db.Entry(gonzales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GonzalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Gonzales
        [ResponseType(typeof(Gonzales))]
        public IHttpActionResult PostGonzales(Gonzales gonzales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gonzales.Add(gonzales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gonzales.GonzalesID }, gonzales);
        }

        // DELETE: api/Gonzales/5
        [ResponseType(typeof(Gonzales))]
        public IHttpActionResult DeleteGonzales(int id)
        {
            Gonzales gonzales = db.Gonzales.Find(id);
            if (gonzales == null)
            {
                return NotFound();
            }

            db.Gonzales.Remove(gonzales);
            db.SaveChanges();

            return Ok(gonzales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GonzalesExists(int id)
        {
            return db.Gonzales.Count(e => e.GonzalesID == id) > 0;
        }
    }
}