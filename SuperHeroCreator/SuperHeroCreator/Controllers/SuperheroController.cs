using SuperHeroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db;
        public SuperheroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Bacon
        public ActionResult Index()
        {
            var allSupes = db.SuperHeroes.ToList();

            return View(allSupes);
        }

        // GET: Bacon/Details/5
        public ActionResult Details(int id)
        {
            var superHeroDetails = db.SuperHeroes.Where(s => s.Id == id).First();
            return View(superHeroDetails);
        }

        // GET: Bacon/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Bacon/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                db.SuperHeroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Bacon/Edit/5
        public ActionResult Edit(int id)
        {
            var heroToEdit = db.SuperHeroes.Where(s => s.Id == id).First();
            return View(heroToEdit);
        }

        // POST: Bacon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                var heroToUpdate = db.SuperHeroes.Where(s => s.Id == superhero.Id).First();
                heroToUpdate.Name = superhero.Name;
                heroToUpdate.AlterEgo = superhero.AlterEgo;
                heroToUpdate.PrimaryAbility = superhero.PrimaryAbility;
                heroToUpdate.SecondaryAbility = superhero.SecondaryAbility;
                heroToUpdate.Catchphrase = superhero.Catchphrase;               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Bacon/Delete/5
        public ActionResult Delete(int id)
        {
            var heroToDelete = db.SuperHeroes.Where(s => s.Id == id).First();
            return View(heroToDelete);
        }

        // POST: Bacon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                var heroToDeleteStill = db.SuperHeroes.Where(s => s.Id == id).First();
                db.SuperHeroes.Remove(heroToDeleteStill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superhero);
            }
        }
    }
}
