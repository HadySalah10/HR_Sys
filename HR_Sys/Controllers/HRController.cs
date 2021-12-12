using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.ViewModels;
using Microsoft.AspNetCore.Session;



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

        public IActionResult checkEmail(string email)
        {
            var user = HrDb.HRs.Where(u => u.email == email).FirstOrDefault();
            if (user != null)
                return Json(false);
                return Json(true);

            

        }

        public IActionResult Login()
        {
            if (Request.Cookies["userId"] != null)
            {
                HttpContext.Session.SetInt32("userId", int.Parse(Request.Cookies["userId"]));
                return RedirectToAction("index");

            }
            return View();
        
        }

        [HttpPost]
        public IActionResult login(HrLoginViewModel user, bool Remember) 
        { 
            if (user != null)

            {
                var dbUser = HrDb.HRs.SingleOrDefault(u => u.email == user.email && u.password == user.password);
                if (dbUser != null)
                {
                    if (Remember == true)
                    {
                        CookieOptions option = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMonths(3)
                        };

                        Response.Cookies.Append("userId", dbUser.hrId.ToString(), option);


                    }


                    HttpContext.Session.SetInt32("userId", dbUser.hrId);

                    HttpContext.Session.SetString("attendAdd", dbUser.Valids.attendAdd.ToString());
                    HttpContext.Session.SetString("attendDelete", dbUser.Valids.attendDelete.ToString());
                    HttpContext.Session.SetString("attendDisplay", dbUser.Valids.attendDisplay.ToString());
                    HttpContext.Session.SetString("attendEdit", dbUser.Valids.attendEdit.ToString());

                    HttpContext.Session.SetString("empAdd", dbUser.Valids.empAdd.ToString());
                    HttpContext.Session.SetString("empDisplay", dbUser.Valids.empDisplay.ToString());
                    HttpContext.Session.SetString("empDelete", dbUser.Valids.empDelete.ToString());
                    HttpContext.Session.SetString("empEdit", dbUser.Valids.empEdit.ToString());

                    HttpContext.Session.SetString("gsAdd", dbUser.Valids.gsAdd.ToString());
                    HttpContext.Session.SetString("gsDisplay", dbUser.Valids.gsDisplay.ToString());
                    HttpContext.Session.SetString("gsDelete", dbUser.Valids.gsDelete.ToString());
                    HttpContext.Session.SetString("gsEdit", dbUser.Valids.gsEdit.ToString());

                    HttpContext.Session.SetString("reportAdd", dbUser.Valids.reportAdd.ToString());
                    HttpContext.Session.SetString("reportDelete", dbUser.Valids.reportDelete.ToString());
                    HttpContext.Session.SetString("reportDisplay", dbUser.Valids.reportDisplay.ToString());
                    HttpContext.Session.SetString("reportEdit", dbUser.Valids.reportEdit.ToString());

                    HttpContext.Session.SetString("group", dbUser.Valids.validationName);




                    return View("welcome");   
                    

                }
                else
                {
                    ViewBag.state = "كلمة مرور خاطئة او بريد الكتروني خاطئ";
                    return View(user);

                }

            }
            else
            {
                ViewBag.state = "من فضلك ادخل اسم مستخدم صالح وكلمة مرور صالحة";

                return View(user);
            }






        }








    }
}
