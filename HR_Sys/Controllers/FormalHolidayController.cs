using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class FormalHolidayController : Controller
    {
        // GET: FormalHolidayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FormalHolidayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormalHolidayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalHolidayController/Create
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

        // GET: FormalHolidayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FormalHolidayController/Edit/5
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

        // GET: FormalHolidayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormalHolidayController/Delete/5
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
