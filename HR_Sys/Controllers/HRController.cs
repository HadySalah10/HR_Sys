using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.ViewModels;

namespace HR_Sys.Controllers
{
    public class HRController : Controller
    {
        HrDBContext HrDb;
        public HRController(HrDBContext HrDb)
        {
            this.HrDb = HrDb;   

        }
        public IActionResult Index()
        {
            return View(HrDb.HRs.ToList());
        }

        public IActionResult RegisterHR()
        {

            ViewBag.validation = new SelectList(HrDb.Validations.ToList(), "id", "validationName");

            return View();
        }
         [HttpPost]  
        public IActionResult RegisterHR(HrRegisterationViewModel user)
        {
            if (ModelState.IsValid)
            {
                HR newUser = new HR();
                newUser.fullName = user.fullName;
                newUser.hrUserName = user.hrUserName;
                newUser.email = user.email;
                newUser.password = user.password;
                newUser.confirmPassword = user.confirmPassword;
                newUser.validationId=user.validationId;
                HrDb.Add(newUser);
                HrDb.SaveChanges();

            }
            else
            {
                ViewBag.validation = new SelectList(HrDb.Validations.ToList(), "id", "validationName");

                return View();
            }

            return RedirectToAction("index");
        }


        public IActionResult editHr(int id)
        {
            var user = HrDb.HRs.Find(id);

            EditHrViewModel hrUser = new EditHrViewModel();
            hrUser.hrId = user.hrId;
            hrUser.fullName = user.fullName;
            hrUser.hrUserName = user.hrUserName;
            hrUser.email = user.email;
            hrUser.validationId = user.validationId;

            ViewBag.validation = new SelectList(HrDb.Validations.ToList(), "id", "validationName");


            return View(hrUser);
       
        }
        [HttpPost]
        public IActionResult editHr(EditHrViewModel user)

        {
            //ModelState.Remove("password");
            //ModelState.Remove("confirmPassword");


            if (ModelState.IsValid)
            {
                var userFromDB = HrDb.HRs.Find(user.hrId);


                userFromDB.fullName = user.fullName;
                userFromDB.hrUserName = user.hrUserName;
                userFromDB.email = user.email;
                userFromDB.validationId = user.validationId;


                //userFromDB.fullName = user.fullName;
                //userFromDB.hrUserName = user.hrUserName;
                //userFromDB.email = user.email;
                //userFromDB.validationId = user.validationId;
                HrDb.SaveChanges();
                return RedirectToAction("index");


            }
            else
            {
                ViewBag.validation = new SelectList(HrDb.Validations.ToList(), "id", "validationName");

                return View();
            }



        }
        public IActionResult deleteHR(int id)
        {
            var delUser = HrDb.HRs.Find(id);
            HrDb.HRs.Remove(delUser);
            HrDb.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult AddValidation()
        {
            return View();
        }
        public IActionResult Permissions() { 

            return View(); 
        
        }

 



    }
}
