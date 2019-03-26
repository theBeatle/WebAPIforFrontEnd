using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjectAPI.Controllers
{
    /// <summary>
    /// API CRUD controller for Worker
    /// </summary>
    [RoutePrefix("Api/Workers")]
    public class WorkersController : ApiController
    {
        private readonly Factory db = new Factory();

        // GET: api/Workers
        /// <summary>
        ///  Get info about all Workers in DB
        /// </summary>
        /// <returns>All Workers info</returns>
        [HttpGet]
        [Route("ReadAllWorkersInfo")]
        public IQueryable<Worker> GetWorkers()
        {
            return db.Workers;
        }

        // GET: api/Workers/5
        /// <summary>
        /// Get Worker by known Id
        /// </summary>
        /// <param name="id">Worker Id to find</param>
        /// <returns>Worker or null</returns>
        [HttpGet]
        [ResponseType(typeof(Worker))]
        [Route("ReadWorkerById/{id}")]
        public IHttpActionResult GetWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // PUT: api/Workers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateWorker/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorker([FromUri] int id, [FromBody] Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest();
            }

            db.Entry(worker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Workers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateWorker")]
        [ResponseType(typeof(Worker))]
        public IHttpActionResult PostWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(worker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteWorkerById/{id}")]
        [ResponseType(typeof(Worker))]
        public IHttpActionResult DeleteWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            db.Workers.Remove(worker);
            db.SaveChanges();

            return Ok(worker);
        }

        /// <summary>
        /// Realize IDisposeable interface
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerExists(int id)
        {
            return db.Workers.Count(e => e.Id == id) > 0;
        }
    }
}