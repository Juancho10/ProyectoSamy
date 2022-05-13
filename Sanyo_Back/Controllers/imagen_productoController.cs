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
    public class imagen_productoController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/imagen_producto
        public IQueryable<imagen_producto> Getimagen_producto()
        {
            return db.imagen_producto;
        }

        // GET: api/imagen_producto/5
        [ResponseType(typeof(imagen_producto))]
        public IHttpActionResult Getimagen_producto(int id)
        {
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            if (imagen_producto == null)
            {
                return NotFound();
            }

            return Ok(imagen_producto);
        }

        // PUT: api/imagen_producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putimagen_producto(int id, imagen_producto imagen_producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagen_producto.id_imagen)
            {
                return BadRequest();
            }

            db.Entry(imagen_producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!imagen_productoExists(id))
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

        // POST: api/imagen_producto
        [ResponseType(typeof(imagen_producto))]
        public IHttpActionResult Postimagen_producto(imagen_producto imagen_producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.imagen_producto.Add(imagen_producto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (imagen_productoExists(imagen_producto.id_imagen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = imagen_producto.id_imagen }, imagen_producto);
        }

        // DELETE: api/imagen_producto/5
        [ResponseType(typeof(imagen_producto))]
        public IHttpActionResult Deleteimagen_producto(int id)
        {
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            if (imagen_producto == null)
            {
                return NotFound();
            }

            db.imagen_producto.Remove(imagen_producto);
            db.SaveChanges();

            return Ok(imagen_producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool imagen_productoExists(int id)
        {
            return db.imagen_producto.Count(e => e.id_imagen == id) > 0;
        }
    }
}