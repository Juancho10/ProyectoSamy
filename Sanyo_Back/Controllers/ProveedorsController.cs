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
    public class ProveedorsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Proveedors
        public IQueryable<Proveedor> GetProveedor()
        {
            return db.Proveedor;
        }

        // GET: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedor(int id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.nit_empresa)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedor.Add(proveedor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProveedorExists(proveedor.nit_empresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proveedor.nit_empresa }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedor.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(int id)
        {
            return db.Proveedor.Count(e => e.nit_empresa == id) > 0;
        }
    }
}