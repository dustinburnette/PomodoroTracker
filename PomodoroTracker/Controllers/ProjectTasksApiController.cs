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
    public class ProjectTasksApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProjectTasksApi
        public IQueryable<ProjectTask> GetProjectTasks()
        {
            return db.ProjectTasks;
        }

        // GET: api/ProjectTasksApi/5
        [ResponseType(typeof(ProjectTask))]
        public IHttpActionResult GetProjectTask(int id)
        {
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return Ok(projectTask);
        }

        // PUT: api/ProjectTasksApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjectTask(int id, ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTask.ProjectTaskID)
            {
                return BadRequest();
            }

            db.Entry(projectTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskExists(id))
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

        // POST: api/ProjectTasksApi
        [ResponseType(typeof(ProjectTask))]
        public IHttpActionResult PostProjectTask(ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectTasks.Add(projectTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectTask.ProjectTaskID }, projectTask);
        }

        // DELETE: api/ProjectTasksApi/5
        [ResponseType(typeof(ProjectTask))]
        public IHttpActionResult DeleteProjectTask(int id)
        {
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            db.ProjectTasks.Remove(projectTask);
            db.SaveChanges();

            return Ok(projectTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectTaskExists(int id)
        {
            return db.ProjectTasks.Count(e => e.ProjectTaskID == id) > 0;
        }
    }
}