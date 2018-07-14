using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RepoPattern.Models;
using RepoPattern.Repository;

namespace RepoPattern.Controllers
{
    public class PersonController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        GenericsRepository<Person> personGenericsRepository = new GenericsRepository<Person>(new ApplicationDbContext());


        // GET: Person
        public ActionResult Index()
        {
            return View(personGenericsRepository.GetAll());
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person person = await personGenericsRepository.GetByIdAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await personGenericsRepository.InsertAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await personGenericsRepository.GetByIdAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await personGenericsRepository.EditAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await personGenericsRepository.GetByIdAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> DeleteConfirmed(int id)
        {
            Person person = await personGenericsRepository.GetByIdAsync(id);
            await personGenericsRepository.DeletetAsync(person);
            return RedirectToAction("Index");
        }

       
    }
}
