using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Sys.Controllers
{
    public class AnnualHolidays : Controller
    {
        //Conntect DB With DC
        HrDBContext db;
        public AnnualHolidays(HrDBContext db)
        {
            this.db = db;
        }

        //Index
        public IActionResult Index()
        {
            ViewBag.NameAnnualHoliday = new SelectList(db.AnnualHolidays.ToList(), "idHoliday", "NameAnnualHoliday");
            //ViewBag.annulholiday = db.annualHoliday.ToList();
            return View(db.AnnualHolidays.ToList());
        }

        //[HttpPost]
        //public IActionResult Index(annualHoliday holidays)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.annualHoliday.Add(holidays);
        //        ViewBag.NameAnnualHoliday = new SelectList(db.NameAnnualHolidays.ToList(), "id", "nameHoliday");
        //        ViewBag.annulholiday = db.annualHoliday.ToList();
        //        db.SaveChanges();
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.NameAnnualHoliday = new SelectList(db.NameAnnualHolidays.ToList(), "id", "nameHoliday");
        //        ViewBag.annulholiday = db.annualHoliday.ToList();

        //        return View();
        //    }
        //}

        //GET: Create 
        public IActionResult Create() 
        {

            ViewBag.NameAnnualHoliday = new SelectList(db.AnnualHolidays.ToList(), "idHoliday", "NameAnnualHoliday");
            return View();
        }

        //Post: Create
        [HttpPost]
        public IActionResult Create(annualHoliday holidays)
        {

            //annualHoliday annualHolidayModel = new annualHoliday()
            //{
            //    NameAnnualHoliday = holidays.NameAnnualHoliday,
            //    dateHoliday = holidays.dateHoliday,
            //};
            if (ModelState.IsValid)
            {
                db.AnnualHolidays.Add(holidays);    
                db.SaveChanges();
            }
                return RedirectToAction("Index");
            
           
        }

        //Get: Edit
        public IActionResult Edit( int id)
        {
            var AnnualHolidays = db.AnnualHolidays.Find(id);
           // ViewBag.NameAnnualHoliday = new SelectList(db.NameAnnualHolidays.ToList(), "id", "nameHoliday");

            return View(AnnualHolidays);
        }

        //Post: Edit
        [HttpPost]
        public IActionResult Edit(annualHoliday holidays)
        {
            //annualHoliday ah = db.AnnualHolidays.Find(holidays.idHoliday);
            annualHoliday annual = db.annualHoliday.Find(holidays.id);
         //   annual.idHoliday = holidays.idHoliday;
            annual.dateHoliday = holidays.dateHoliday;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            annualHoliday ah = db.annualHoliday.Find(id);
            db.annualHoliday.Remove(ah);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
