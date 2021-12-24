using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;

namespace HR_Sys.Controllers
{
    public class FormalHolidayController : Controller
    {
        HrDBContext _db;
        public FormalHolidayController(HrDBContext context)
        {
            _db = context;
        }
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

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("empDelete") == "True")
            {
                var typeofvacation = _db.TypesOfVacationsEmps.Find(id);
                if (typeofvacation.id > 0 || typeofvacation != null)
                    typeofvacation.isDeleted = true;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("ErrorPage");

        }
    }
}
