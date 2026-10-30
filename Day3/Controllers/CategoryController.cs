using Day3.Data;
using Day3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = Day3.Data.SeedClass.categories;
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            // lay ra category co id truyen vao tu SeedClass
            var category = Day3.Data.SeedClass.categories.FirstOrDefault(c => c.Id == id);
            // neu category=null thi tra ve trang loi
            if (category == null)
            {
                return NotFound();
            }
            // neu category khac null thi tra ve view va truyen category vao view
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category)
        {
            if(ModelState.IsValid)
            {
                int maxId = Day3.Data.SeedClass.categories.Max(c => c.Id);
                category.Id = maxId + 1;
                // add category vao SeedClass.categories
                   SeedClass.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SeedClass.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var existingCategory = SeedClass.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));

            }
            return View(category);

        }
        


        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed ([FromRoute] int id)
        {
            var category = SeedClass.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            
                SeedClass.categories.Remove(category);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
