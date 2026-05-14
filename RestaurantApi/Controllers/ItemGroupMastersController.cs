using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantApi;
using System.Web.Http.Cors;

namespace RestaurantApi.Controllers
{
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemGroupMastersController : ApiController
    {
        private RestCEntities db = new RestCEntities();

        // GET: api/ItemGroupMasters
        public IQueryable<ItemGroupMaster> GetItemGroupMasters()
        {
            return db.ItemGroupMasters;
        }

        // GET: api/ItemGroupMasters/5
        [ResponseType(typeof(ItemGroupMaster))]
        public async Task<IHttpActionResult> GetItemGroupMaster(long id)
        {
            ItemGroupMaster itemGroupMaster = await db.ItemGroupMasters.FindAsync(id);
            if (itemGroupMaster == null)
            {
                return NotFound();
            }

            return Ok(itemGroupMaster);
        }

        // PUT: api/ItemGroupMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemGroupMaster(long id, ItemGroupMaster itemGroupMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemGroupMaster.GroupID)
            {
                return BadRequest();
            }

            db.Entry(itemGroupMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupMasterExists(id))
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

        // POST: api/ItemGroupMasters
        [ResponseType(typeof(ItemGroupMaster))]
        public async Task<IHttpActionResult> PostItemGroupMaster(ItemGroupMaster itemGroupMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemGroupMasters.Add(itemGroupMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemGroupMaster.GroupID }, itemGroupMaster);
        }

        // DELETE: api/ItemGroupMasters/5
        [ResponseType(typeof(ItemGroupMaster))]
        public async Task<IHttpActionResult> DeleteItemGroupMaster(long id)
        {
            ItemGroupMaster itemGroupMaster = await db.ItemGroupMasters.FindAsync(id);
            if (itemGroupMaster == null)
            {
                return NotFound();
            }

            db.ItemGroupMasters.Remove(itemGroupMaster);
            await db.SaveChangesAsync();

            return Ok(itemGroupMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemGroupMasterExists(long id)
        {
            return db.ItemGroupMasters.Count(e => e.GroupID == id) > 0;
        }
    }
}