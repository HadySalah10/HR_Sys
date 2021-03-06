using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.ViewModels;
using Microsoft.AspNetCore.Session;
using X.PagedList;

namespace HR_Sys.Controllers

{
    public class HRController : Controller
    {
        HrDBContext db;
        public HRController(HrDBContext db)
        {
            this.db = db;

        }
        public IActionResult welcome()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {

                var hr = db.HRs.Find(HttpContext.Session.GetInt32("userId"));

                var id = HttpContext.Session.GetInt32("userId");

                ViewBag.hrname = hr.hrUserName;
            }
            ViewBag.empnumber = db.Employees.Where(n => n.isDeleted == false).Count();
            ViewBag.hrnumbers = db.HRs.Count();
            ViewBag.deptnumbers = db.Departments.Where(n => n.isDeleted == false).Count();
            return View();
        }
        public IActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                ViewBag.page = searchString;
                ViewBag.pageNum = page;

                page = page > 0 ? page : 1;

                pageSize = pageSize > 0 ? pageSize : 7;
                var hrs = db.HRs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    hrs = hrs.Where(n => n.hrUserName.Contains(searchString)).ToList();

                }

                return View(hrs.ToPagedList(page, pageSize));

            }
            return View("ErrorPage");
        }

        public IActionResult search(string searchString, int page = 1, int pageSize = 2)
        {
            page = page > 0 ? page : 1;

            pageSize = pageSize > 0 ? pageSize : 7;

            var users = db.HRs.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {

                users = users.Where(n => n.hrUserName.Contains(searchString)).ToList();

            }

            ViewBag.search = searchString;

            return PartialView(users.ToPagedList(page, pageSize));
        }




        public IActionResult RegisterHR()
        {
            if (HttpContext.Session.GetString("group") == "Admin")

            {
                ViewBag.validation = new SelectList(db.Validations.ToList(), "id", "validationName");

                return View();
            }

            return View("ErrorPage");

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
                newUser.validationId = user.validationId;
                db.HRs.Add(newUser);
                db.SaveChanges();

            }
            else
            {
                ViewBag.validation = new SelectList(db.Validations.ToList(), "id", "validationName");

                return View();
            }

            return RedirectToAction("index");
        }


        public IActionResult editHr(int id)
        {
            if (HttpContext.Session.GetString("group") == "Admin")

            {
                var user = db.HRs.Find(id);

                EditHrViewModel hrUser = new EditHrViewModel();
                hrUser.hrId = user.hrId;
                hrUser.fullName = user.fullName;
                hrUser.hrUserName = user.hrUserName;
                hrUser.email = user.email;
                hrUser.validationId = user.validationId;

                ViewBag.validation = new SelectList(db.Validations.ToList(), "id", "validationName");


                return View(hrUser);
            }

            return View("ErrorPage");


        }
        [HttpPost]
        public IActionResult editHr(EditHrViewModel user)

        {
            //ModelState.Remove("password");
            //ModelState.Remove("confirmPassword");


            if (ModelState.IsValid)
            {
                var userFromDB = db.HRs.Find(user.hrId);


                userFromDB.fullName = user.fullName;
                userFromDB.hrUserName = user.hrUserName;
                userFromDB.email = user.email;
                userFromDB.validationId = user.validationId;


                //userFromDB.fullName = user.fullName;
                //userFromDB.hrUserName = user.hrUserName;
                //userFromDB.email = user.email;
                //userFromDB.validationId = user.validationId;
                db.SaveChanges();
                return RedirectToAction("index");


            }
            else
            {
                ViewBag.validation = new SelectList(db.Validations.ToList(), "id", "validationName");

                return View();
            }



        }
        public IActionResult deleteHR(int id)
        {
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                var delUser = db.HRs.Find(id);
                db.HRs.Remove(delUser);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("ErrorPage");
        }

        public IActionResult AddValidation()
        {
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                return View();
            }

            else
            {
                return View("ErrorPage");
            }

        }
        [HttpPost]
        public IActionResult AddValidation(addvalidationviewmodel valid)
        {
            if (ModelState.IsValid)
            {
                Validations val = new Validations()
                {
                    validationName = valid.validationName,
                    empAdd = valid.empAdd,
                    empEdit = valid.empEdit,
                    empDelete = valid.empDelete,
                    empDisplay = valid.empDisplay,
                    gsAdd = valid.gsAdd,
                    gsEdit = valid.gsEdit,
                    gsDelete = valid.gsDelete,
                    gsDisplay = valid.gsDisplay,
                    attendAdd = valid.attendAdd,
                    attendEdit = valid.attendEdit,
                    attendDelete = valid.attendDelete,
                    attendDisplay = valid.attendDisplay,
                    reportAdd = valid.reportAdd,
                    reportEdit = valid.reportEdit,
                    reportDelete = valid.reportDelete,
                    reportDisplay = valid.reportDisplay
                };

                db.Validations.Add(val);
                db.SaveChanges();
                return RedirectToAction("allvalidations");
            }
            else
            {
                return View();

            }




        }
        public IActionResult Permissions()
        {

            return View();

        }

        public IActionResult checkEmail(string email)
        {
            var user = db.HRs.Where(u => u.email == email).FirstOrDefault();
            if (user != null)
                return Json(false);
            return Json(true);
        }
        public ActionResult logout()
        {

            HttpContext.Session.Clear();
            Response.Cookies.Delete("email");
            Response.Cookies.Delete("password");
            Response.Cookies.Delete("userId");
            return RedirectToAction("login");
        }

        public IActionResult Login()
        {

            var dbUser = db.HRs.SingleOrDefault(u => u.email == Request.Cookies["email"] && u.password == Request.Cookies["password"]);
            if (HttpContext.Session.GetString("userId") != null)
            {
                return RedirectToAction("welcome");
            }
            if (Request.Cookies["userId"] != null && dbUser != null)
            {
                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(3)
                };
                HttpContext.Session.SetInt32("userId", int.Parse(Request.Cookies["userId"]));


                setSession(dbUser);



                return RedirectToAction("welcome");
            }
            return View();

        }

        [HttpPost]
        public IActionResult login(HrLoginViewModel user, bool Remember)
        {

            if (user != null)

            {
                var dbUser = db.HRs.SingleOrDefault(u => u.email == user.email && u.password == user.password);
                if (dbUser != null)
                {
                    if (Remember == true)
                    {
                        CookieOptions option = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMonths(3)
                        };

                        Response.Cookies.Append("userId", dbUser.hrId.ToString(), option);
                        Response.Cookies.Append("email", dbUser.email.ToString(), option);
                        Response.Cookies.Append("password", dbUser.password.ToString(), option);


                    }

                    setSession(dbUser);



                    return RedirectToAction("welcome");


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

        private void setSession(HR dbUser)
        {

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

        }
        public IActionResult allvalidations()
        {

            return View(db.Validations.ToList());
        }

        public IActionResult deletevalidation(int id)
        {
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                Validations val = db.Validations.Find(id);
                db.Validations.Remove(val);
                db.SaveChanges();
                return RedirectToAction("allvalidations");
            }
            return View("ErrorPage");
        }
        public IActionResult editvalidation(int id)
        {
            if (HttpContext.Session.GetString("group") == "Admin")
            {
                var hr = db.Validations.Find(id);
                return View(hr);
            }
            return View("ErrorPage");
        }
        [HttpPost]
        public IActionResult editvalidation(addvalidationviewmodel valid)
        {

      
                if (ModelState.IsValid)
                {
                    var hr = db.Validations.Find(valid.id);
                    hr.validationName = valid.validationName;
                    hr.empAdd = valid.empAdd;
                    hr.empEdit = valid.empEdit;
                    hr.empDelete = valid.empDelete;
                    hr.empDisplay = valid.empDisplay;
                    hr.gsAdd = valid.gsAdd;
                    hr.gsEdit = valid.gsEdit;
                    hr.gsDelete = valid.gsDelete;
                    hr.gsDisplay = valid.gsDisplay;
                    hr.attendAdd = valid.attendAdd;
                    hr.attendEdit = valid.attendEdit;
                    hr.attendDelete = valid.attendDelete;
                    hr.attendDisplay = valid.attendDisplay;
                    hr.reportAdd = valid.reportAdd;
                    hr.reportEdit = valid.reportEdit;
                    hr.reportDelete = valid.reportDelete;
                    hr.reportDisplay = valid.reportDisplay;
                    db.SaveChanges();
                    return RedirectToAction("allvalidations");

                }
            return View();
           


           
        }


    }
    }
