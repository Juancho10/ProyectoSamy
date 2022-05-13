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
    public class CompraController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Compra
        public IQueryable<Compra> GetCompra()
        {
            return db.Compra;
        }

        // GET: api/Compra/5
        [ResponseType(typeof(Compra))]
        public IHttpActionResult GetCompra(int id)
        {
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // PUT: api/Compra/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompra(int id, Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra.id_compra)
            {
                return BadRequest();
            }

            db.Entry(compra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // POST: api/Compra
        [ResponseType(typeof(Compra))]
        public IHttpActionResult PostCompra(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Compra.Add(compra);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompraExists(compra.id_compra))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = compra.id_compra }, compra);
        }

        // DELETE: api/Compra/5
        [ResponseType(typeof(Compra))]
        public IHttpActionResult DeleteCompra(int id)
        {
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            db.Compra.Remove(compra);
            db.SaveChanges();

            return Ok(compra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraExists(int id)
        {
            return db.Compra.Count(e => e.id_compra == id) > 0;
        }
    }
}