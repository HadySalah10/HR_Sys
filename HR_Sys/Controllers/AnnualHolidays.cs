using HR_Sys.Models;
using HR_Sys.ViewModels;
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
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                // ViewBag.NameAnnualHoliday = new SelectList(db.AnnualHolidays.ToList(), "idHoliday", "NameAnnualHoliday");
                //ViewBag.annulholiday = db.annualHoliday.ToList();
                return View(db.AnnualHolidays.ToList());
            }
            return View("ErrorPage");
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
            if(HttpContext.Session.GetString("group") == "Admin")
            {

             // ViewBag.NameAnnualHoliday = new SelectList(db.AnnualHolidays.ToList(), "idHoliday", "NameAnnualHoliday");
                return View();
            }
            return View("ErrorPage");
        }

        //Post: Create
        [HttpPost]
        public IActionResult Create(annualHolidayViewModel holidays)
        {
            if (ModelState.IsValid)
            {
                annualHoliday holiday = new annualHoliday();
                holiday.nameHoliday = holidays.NameHoliday;
                holiday.dateHoliday = holidays.DateHoliday;
               db.annualHoliday.Add(holiday);    
                db.SaveChanges();
               
            }
                return RedirectToAction("Index");
            
           
        }

        //Get: Edit
        public IActionResult Edit( int id)
        {
            if (HttpContext.Session.GetString("group") == "Admin")

            {
                var AnnualHolidays = db.AnnualHolidays.Find(id);
                annualHolidayViewModel editAnnualHoliday = new annualHolidayViewModel();
                editAnnualHoliday.Id = AnnualHolidays.id;
                editAnnualHoliday.NameHoliday = AnnualHolidays.nameHoliday;
                editAnnualHoliday.DateHoliday = (DateTime)AnnualHolidays.dateHoliday;

                return View(editAnnualHoliday);
            }
            return View("ErrorPage");
        }

        //Post: Edit
        [HttpPost]
        public IActionResult Edit(annualHolidayViewModel holidays)
        {
            if (ModelState.IsValid)
            {
                var holiday = db.annualHoliday.Find(holidays.Id);
                holiday.nameHoliday = holidays.NameHoliday;
                holiday.dateHoliday = holidays.DateHoliday;
                
                db.SaveChanges();

            }
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
