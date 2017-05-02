using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PomodoroTracker.Models;

namespace PomodoroTracker.Controllers
{
    public class PomodoroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pomodoroes
        public ActionResult Index()
        {
            var pomodoroes = db.Pomodoroes.Include(p => p.ProjectTask);
            return View(pomodoroes.ToList());
        }

        // GET: Pomodoroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            if (pomodoro == null)
            {
                return HttpNotFound();
            }
            return View(pomodoro);
        }

        // GET: Pomodoroes/Create
        public ActionResult Create()
        {
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTasks, "ProjectTaskID", "Description");
            return View();
        }

        // POST: Pomodoroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PomodoroID,ProjectTaskID,StartTime,DurationInMinutes")] Pomodoro pomodoro)
        {
            if (ModelState.IsValid)
            {
                db.Pomodoroes.Add(pomodoro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectTaskID = new SelectList(db.ProjectTasks, "ProjectTaskID", "Description", pomodoro.ProjectTaskID);
            return View(pomodoro);
        }

        // GET: Pomodoroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            if (pomodoro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTasks, "ProjectTaskID", "Description", pomodoro.ProjectTaskID);
            return View(pomodoro);
        }

        // POST: Pomodoroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PomodoroID,ProjectTaskID,StartTime,DurationInMinutes")] Pomodoro pomodoro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pomodoro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectTaskID = new SelectList(db.ProjectTasks, "ProjectTaskID", "Description", pomodoro.ProjectTaskID);
            return View(pomodoro);
        }

        // GET: Pomodoroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            if (pomodoro == null)
            {
                return HttpNotFound();
            }
            return View(pomodoro);
        }

        // POST: Pomodoroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pomodoro pomodoro = db.Pomodoroes.Find(id);
            db.Pomodoroes.Remove(pomodoro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
