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
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class UsersClassModelsController : ApiController
    {
        private WebMazeContext db = new WebMazeContext();

        // GET: api/UsersClassModels
        public IQueryable<UsersClassModel> GetUsersClassModels()
        {
            return db.UsersClassModels;
        }

        //find key
        //find key
        // GET: api/UsersClassModels/5
        [ResponseType(typeof(UsersClassModel))]
        public async Task<IHttpActionResult> GetUsersClassModel(string id)
        {
            UsersClassModel usersClassModel = await db.UsersClassModels.FindAsync(id);
            if (usersClassModel == null)
            {
                return NotFound();
            }

            return Ok(usersClassModel);
        }

        // GET: api/UsersClassModels/5
        [ResponseType(typeof(UsersClassModel))]
        [HttpGet]
        [Route("api/UsersClassModels/5/{userName}")]

        public async Task<string> GetUsersClassModelAsync(string userName)
        {
            UsersClassModel usersClassModel = await db.UsersClassModels.FindAsync(userName);
            if (usersClassModel == null)
            {
                return "error";
            }

            return usersClassModel.Password;
        }

        // PUT: api/UsersClassModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsersClassModel(string id, UsersClassModel usersClassModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersClassModel.UserName)
            {
                return BadRequest();
            }

            db.Entry(usersClassModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersClassModelExists(id))
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

        //add new
        // POST: api/UsersClassModels
        [ResponseType(typeof(UsersClassModel))]
        [HttpPost]
        [Route("api/UsersClassModels/{userName}/{password}")]
        public string PostUsersClassModel(string userName, string password)
        {
            UsersClassModel usersClassModel = new UsersClassModel();
            usersClassModel.UserName = userName;
            usersClassModel.Password = password;
            db.UsersClassModels.Add(usersClassModel);
            db.SaveChanges();
            return "success";
        }

        // POST: api/UsersClassModels
        [ResponseType(typeof(UsersClassModel))]
        public async Task<IHttpActionResult> PostUsersClassModel(UsersClassModel usersClassModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersClassModels.Add(usersClassModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersClassModelExists(usersClassModel.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usersClassModel.UserName }, usersClassModel);
        }

        // DELETE: api/UsersClassModels/5
        [ResponseType(typeof(UsersClassModel))]
        public async Task<IHttpActionResult> DeleteUsersClassModel(string id)
        {
            UsersClassModel usersClassModel = await db.UsersClassModels.FindAsync(id);
            if (usersClassModel == null)
            {
                return NotFound();
            }

            db.UsersClassModels.Remove(usersClassModel);
            await db.SaveChangesAsync();

            return Ok(usersClassModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersClassModelExists(string id)
        {
            return db.UsersClassModels.Count(e => e.UserName == id) > 0;
        }
    }
}