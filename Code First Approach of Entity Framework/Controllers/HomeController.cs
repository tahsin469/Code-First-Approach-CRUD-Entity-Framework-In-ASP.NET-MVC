using Code_First_Approach_of_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Approach_of_Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted!!')</script>";
                    //ModelState.Clear();
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted!!')</script>";
                    TempData["InsertMessage"] = "Data Inserted!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted!!')</script>";
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted!!')</script>";
                    //ModelState.Clear();
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted!!')</script>";
                    TempData["UpdateMessage"] = "Data Modified!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Modified!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var StudentIDrow = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(StudentIDrow);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted!!')</script>";
                    //ModelState.Clear();
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted!!')</script>";
                    TempData["DeletedMessage"] = "Data Removed!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.DeletedMessage = "<script>alert('Data Not Removed!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(DetailsById);
        }
    }
}