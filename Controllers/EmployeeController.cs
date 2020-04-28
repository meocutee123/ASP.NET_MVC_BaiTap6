using BaiTap6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly QLNVEntities emp = new QLNVEntities();
        // GET: Employee
        public ActionResult Division()
        {
            return View(emp.PhongBans.ToList());
        }
        public ActionResult Employee()
        {
            return View(emp.NhanViens.ToList());
        }
        public ActionResult Index()
        {
            return View(emp.NhanViens.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            string path = Server.MapPath("~/Images/");
            string fileName = Path.GetFileName(nv.empImg.FileName);
            string fullPath = Path.Combine(path, fileName);
            nv.anhNhanVien = "~/Images/" + fileName;
            nv.empImg.SaveAs(fullPath);
            try
            {
                emp.NhanViens.Add(nv);
                emp.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            return View(emp.NhanViens.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            emp.Entry(nv).State = EntityState.Modified;
            emp.SaveChanges();
            ViewBag.Message = "Successful!";
            return View(nv);
        }

        public ActionResult Delete(int id = 0)
        {
            return View(emp.NhanViens.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(NhanVien nv, int id = 0)
        {
            nv = emp.NhanViens.Where(x => x.Id == id).FirstOrDefault();
            emp.NhanViens.Remove(nv);
            emp.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id = 0)
        {
            return View(emp.NhanViens.Where(x => x.Id == id).FirstOrDefault());
        }
        public ActionResult Search(string search)
        {
            return View(emp.NhanViens.Where(x => x.tenNhanVien.Contains(search) || search == null).ToList());
        }
    }
}