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
    public class detalle_pedidoController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/detalle_pedido
        public IQueryable<detalle_pedido> Getdetalle_pedido()
        {
            return db.detalle_pedido;
        }

        // GET: api/detalle_pedido/5
        [ResponseType(typeof(detalle_pedido))]
        public IHttpActionResult Getdetalle_pedido(string id)
        {
            detalle_pedido detalle_pedido = db.detalle_pedido.Find(id);
            if (detalle_pedido == null)
            {
                return NotFound();
            }

            return Ok(detalle_pedido);
        }

        // PUT: api/detalle_pedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdetalle_pedido(string id, detalle_pedido detalle_pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle_pedido.id_stock)
            {
                return BadRequest();
            }

            db.Entry(detalle_pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detalle_pedidoExists(id))
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

        // POST: api/detalle_pedido
        [ResponseType(typeof(detalle_pedido))]
        public IHttpActionResult Postdetalle_pedido(detalle_pedido detalle_pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.detalle_pedido.Add(detalle_pedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (detalle_pedidoExists(detalle_pedido.id_stock))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detalle_pedido.id_stock }, detalle_pedido);
        }

        // DELETE: api/detalle_pedido/5
        [ResponseType(typeof(detalle_pedido))]
        public IHttpActionResult Deletedetalle_pedido(string id)
        {
            detalle_pedido detalle_pedido = db.detalle_pedido.Find(id);
            if (detalle_pedido == null)
            {
                return NotFound();
            }

            db.detalle_pedido.Remove(detalle_pedido);
            db.SaveChanges();

            return Ok(detalle_pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool detalle_pedidoExists(string id)
        {
            return db.detalle_pedido.Count(e => e.id_stock == id) > 0;
        }
    }
}