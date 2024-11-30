using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IHAVENOIDEAS.Controllers
{
    public class ArtController : Controller
    {
        // GET: ArtController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArtController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
