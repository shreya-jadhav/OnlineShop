using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagNamesController : Controller
    {
        private ApplicationDbContext _db;

        public TagNamesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.TagNames.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagNames tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.TagNames.Add(tagNames);
                await _db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }

            return View(tagNames);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagNames = _db.TagNames.Find(id);
            if (tagNames == null)
            {
                return NotFound();
            }
            return View(tagNames);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagNames tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tagNames);
                await _db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }

            return View(tagNames);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(TagNames tagNames)
        {
            return View(tagNames);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, TagNames tagNames)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != tagNames.Id)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(tagName);
                await _db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }

            return View(tagNames);
        }
    }
}
