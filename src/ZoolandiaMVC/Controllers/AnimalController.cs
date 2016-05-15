using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ZoolandiaMVC.Models;

namespace ZoolandiaMVC.Controllers
{
    public class AnimalController : Controller
    {
        private ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Animals
        public IActionResult Index()
        {
            var AnimalInfo = 
                (from animal in _context.Animal
                join habitat in _context.Habitat
                on animal.IdHabitat equals habitat.ID
                
                join species in _context.Species
                on animal.IdSpecies equals species.ID

                //basically means 'create new' based on search results
                select new
                {
                    animal = animal.Name,
                    animalHabitatName = habitat.Name,
                    animalSpecies = species.CommonName

                }).ToList();
            return View(AnimalInfo);
        }

        // GET: Animals/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Animal animal = _context.Animal.Single(m => m.ID == id);
            if (animal == null)
            {
                return HttpNotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animal.Add(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Animal animal = _context.Animal.Single(m => m.ID == id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Update(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Animal animal = _context.Animal.Single(m => m.ID == id);
            if (animal == null)
            {
                return HttpNotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Animal animal = _context.Animal.Single(m => m.ID == id);
            _context.Animal.Remove(animal);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
