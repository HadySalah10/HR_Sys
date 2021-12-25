using HR_Sys.Models;
using HR_Sys.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class DepartmentController : Controller
    {
        //Conntect DB With DC
        HrDBContext db;
        public DepartmentController(HrDBContext db)
        {
            this.db = db;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        public ActionResult Create(CreateDepartmentViewModel dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department dep = new Department();
                    dep.deptName = dept.deptName;
                    db.Add(dep);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var Department = db.Departments.Find(id);
            CreateDepartmentViewModel deptsmodel = new CreateDepartmentViewModel();
            deptsmodel.deptId = Department.id;
            deptsmodel.deptName = Department.deptName;
            return View(deptsmodel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateDepartmentViewModel Department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var deptFromDb = db.Departments.Find(Department.deptId);
                    deptFromDb.deptName = Department.deptName;

                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var depts = db.Departments.Find(id);
            db.Departments.Remove(depts);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
