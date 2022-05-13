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
using Sanyo_Back.Models;

namespace Sanyo_Back.Controllers
{
    public class TelefonoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Telefonoes
        public IQueryable<Telefono> GetTelefono()
        {
            return db.Telefono;
        }

        // GET: api/Telefonoes/5
        [ResponseType(typeof(Telefono))]
        public IHttpActionResult GetTelefono(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return Ok(telefono);
        }

        // PUT: api/Telefonoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefono(int id, Telefono telefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefono.id_telefono)
            {
                return BadRequest();
            }

            db.Entry(telefono).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(id))
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

        // POST: api/Telefonoes
        [ResponseType(typeof(Telefono))]
        public IHttpActionResult PostTelefono(Telefono telefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefono.Add(telefono);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TelefonoExists(telefono.id_telefono))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = telefono.id_telefono }, telefono);
        }

        // DELETE: api/Telefonoes/5
        [ResponseType(typeof(Telefono))]
        public IHttpActionResult DeleteTelefono(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return NotFound();
            }

            db.Telefono.Remove(telefono);
            db.SaveChanges();

            return Ok(telefono);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonoExists(int id)
        {
            return db.Telefono.Count(e => e.id_telefono == id) > 0;
        }
    }
}