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
    public class TipoProductoController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/TipoProducto
        public IQueryable<TipoProducto> GetTipoProducto()
        {
            return db.TipoProducto;
        }

        // GET: api/TipoProducto/5
        [ResponseType(typeof(TipoProducto))]
        public IHttpActionResult GetTipoProducto(int id)
        {
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return Ok(tipoProducto);
        }

        // PUT: api/TipoProducto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoProducto(int id, TipoProducto tipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoProducto.id_tipo_producto)
            {
                return BadRequest();
            }

            db.Entry(tipoProducto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProductoExists(id))
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

        // POST: api/TipoProducto
        [ResponseType(typeof(TipoProducto))]
        public IHttpActionResult PostTipoProducto(TipoProducto tipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoProducto.Add(tipoProducto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TipoProductoExists(tipoProducto.id_tipo_producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipoProducto.id_tipo_producto }, tipoProducto);
        }

        // DELETE: api/TipoProducto/5
        [ResponseType(typeof(TipoProducto))]
        public IHttpActionResult DeleteTipoProducto(int id)
        {
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            db.TipoProducto.Remove(tipoProducto);
            db.SaveChanges();

            return Ok(tipoProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoProductoExists(int id)
        {
            return db.TipoProducto.Count(e => e.id_tipo_producto == id) > 0;
        }
    }
}