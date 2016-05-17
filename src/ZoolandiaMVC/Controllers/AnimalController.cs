using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ZoolandiaMVC.Models;
using ZoolandiaMVC.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.Net.Http.Headers;

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
        public IActionResult Index(string searchString)
        {

            // Create functionality for searching
            var animals = from a in _context.Animal
                          select a;

            

            // access the database and get info for the animal's name and habitat
            var AnimalInfo =
                (from animal in _context.Animal
                 join habitat in _context.Habitat
                 on animal.IdHabitat equals habitat.ID

                 join species in _context.Species
                 on animal.IdSpecies equals species.ID

                 //basically means 'create new' based on search results
                 select new AnimalDataViewModel
                 {
                     ID = animal.ID,
                     animal = animal.Name,
                     animalHabitatName = habitat.Name,
                     animalSpecies = species.CommonName

                 }).ToList();

            // Filter the list for search results
            if (!String.IsNullOrEmpty(searchString))
            {
                var filteredAnimalInfo = AnimalInfo.Where(item => item.animal == searchString);
                return View(filteredAnimalInfo);
            }

            // Pass that information to the view
            return View(AnimalInfo);
        }

        // GET: Animals/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            // Get the specifice animal
            Animal animal = _context.Animal.Single(m => m.ID == id);

            // Get Document table from the database
           
            var docs = (from d in _context.Document
                        orderby d.FileName
                        select new Document
                        {}).ToList();

            DocumentDetailsViewModel vm = new DocumentDetailsViewModel()
            {
                Documents = docs,
                ID = animal.ID,
                IdHabitat = animal.IdHabitat,
                IdSpecies = animal.IdSpecies,
                Name = animal.Name
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Details(IFormFile file, DocumentDetailsViewModel docViewModel)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (file != null && file.Length > 0)
                    try
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {
                            string contentAsString = reader.ReadToEnd();
                            byte[] bytes = new byte[contentAsString.Length * sizeof(char)];
                            System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);
                            var fileType = file.ContentType;
                            Document doc = new Document()
                            {
                                Title = docViewModel.Title,
                                FileName = fileName,
                                Contents = bytes,
                                ContentType = fileType,
                                UploadDate = DateTime.Now,
                                UploadUserId = "williamhickok11@gmail.c0m"
                            };

                            dbContext.Document.Add(doc);
                            dbContext.SaveChanges();
                        }

                        ViewBag.Message = "File uploaded successfully";

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                ////go back to index and the new doc should show
                //var docs = from d in dbContext.Document
                //           orderby d.FileName
                //           select d;

                DocumentDetailsViewModel vm = new DocumentDetailsViewModel()
                {
                    //Documents = docs.ToList()
                };
                return View(vm);
            }
        }


        // GET: Animals/Create
        public IActionResult Create()
        {
            var AnimalFullInfo =
                (from animal in _context.Animal
                 join habitat in _context.Habitat
                 on animal.IdHabitat equals habitat.ID

                 join species in _context.Species
                 on animal.IdSpecies equals species.ID

                 //basically means 'create new' based on search results
                 select new AnimalDataViewModel
                 {
                     ID = animal.ID,
                     animal = animal.Name,
                     animalHabitatName = habitat.Name,
                     animalSpecies = species.CommonName,
                     habitatId = habitat.ID,
                     speciesId = species.ID

                 }).ToList();

            var habitatNameList = new List<string>();
            foreach (var item in AnimalFullInfo)
            {
                habitatNameList.Add(item.animalHabitatName);
            }
            ViewData["habitatList"] = new SelectList(habitatNameList);

            // Pass that information to the view
            return View(AnimalFullInfo);
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
