using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcProjectDemo_.Models;

namespace MvcProjectDemo_.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1, Name="kiran", State="Maharashtra", District="Jalgon", Villege="kingaon", Marks=70.50},
            new Student{Id=2, Name="Sani", State="Maharashtra", District="Dhule", Villege="mukti", Marks=66.50},
            new Student{Id=3, Name="Yash", State="Maharashtra", District="Mumbai", Villege="new mumbai", Marks=88.50},
            new Student{Id=4, Name="Vedant", State="Maharashtra", District="Pune", Villege="Akurdi", Marks=77.50}
        };

        // GET: Students
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

       

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
                return PartialView("_AddEditStudent", student);

            return RedirectToAction("Index");
        }

        // POST: Students/Edit
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Marks = student.Marks;
                    existingStudent.State = student.State;
                    existingStudent.District = student.District;
                    existingStudent.Villege = student.Villege;
                }

                return RedirectToAction("Index");
            }

            return PartialView("_AddEditStudent", student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
                return PartialView("_DeleteStudent", student);

            return RedirectToAction("Index");
        }

        // POST: Students/Delete
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
                students.Remove(existingStudent);

            return RedirectToAction("Index");
        }


    }
}
