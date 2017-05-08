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
using PomodoroTracker.Models;

namespace PomodoroTracker.Controllers
{
    public class PomodoroesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PomodoroesApi
        public IQueryable<Pomodoro> GetPomodoroes()
        {
            return db.Pomodoroes;
        }

        // GET: api/PomodoroesApi/5
        [ResponseType(typeof(Pomodoro))]
        public IHttpActionResult GetPomodoro(int id)
        {
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            if (pomodoro == null)
            {
                return NotFound();
            }

            return Ok(pomodoro);
        }

        // PUT: api/PomodoroesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPomodoro(int id, Pomodoro pomodoro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pomodoro.PomodoroID)
            {
                return BadRequest();
            }

            db.Entry(pomodoro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PomodoroExists(id))
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

        // POST: api/PomodoroesApi
        [ResponseType(typeof(Pomodoro))]
        public IHttpActionResult PostPomodoro(Pomodoro pomodoro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pomodoroes.Add(pomodoro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pomodoro.PomodoroID }, pomodoro);
        }

        // DELETE: api/PomodoroesApi/5
        [ResponseType(typeof(Pomodoro))]
        public IHttpActionResult DeletePomodoro(int id)
        {
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            if (pomodoro == null)
            {
                return NotFound();
            }

            db.Pomodoroes.Remove(pomodoro);
            db.SaveChanges();

            return Ok(pomodoro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PomodoroExists(int id)
        {
            return db.Pomodoroes.Count(e => e.PomodoroID == id) > 0;
        }
    }
}