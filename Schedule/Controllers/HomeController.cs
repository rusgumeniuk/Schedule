using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Schedule.Models.Enums;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;

        public HomeController(DataContext dataContext)
        {
            db = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GroupFind()
        {
            return View(db.Groups);
        }
        public IActionResult TeacherFind()
        {
            return View(db.Teachers);
        }

        [HttpPost]
        public IActionResult GroupSchedule(Guid id)
        {
            var lessons = db.Lessons
                .Include(ls => ls.Group)
                .Include(ls => ls.Teacher)
                .Include(ls => ls.Room)
                .Include(ls => ls.Subject)
                .ToArray()
                .Where(les => les.Group.Id.Equals(id));

            FillViewBag(lessons);
            return View((db.Groups as IQueryable<Group>).FirstOrDefault(gr => gr.Id.Equals(id)));
        }
        [HttpPost]
        public IActionResult TeacherSchedule(Guid id)
        {
            var lessons = db.Lessons
               .Include(ls => ls.Group)
               .Include(ls => ls.Teacher)
               .Include(ls => ls.Room)
               .Include(ls => ls.Subject)
               .ToArray()
               .Where(lesson => lesson.Teacher.Id.Equals(id));

            FillViewBag(lessons);
            return View((db.Teachers as IQueryable<Teacher>).FirstOrDefault(teacher => teacher.Id.Equals(id)));
        }

        private void FillViewBag(IEnumerable<Lesson> lessons)
        {
            ViewBag.Days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            ViewBag.Numbers = Enum.GetValues(typeof(LessonNumber)).Cast<LessonNumber>();
            ViewBag.Lessons = lessons;
        }
    }
}
//    Teacher firstTeacher = new Teacher() { Title = "First Teacher" };
//    Teacher secondTeacher = new Teacher() { Title = "Second Teacher" };                       

//    Group it62 = new Group() { Title = "IT-62" };
//    Group it52 = new Group() { Title = "IA-52" };

//    Subject math = new Subject() { Title = "Math" };
//    Subject english = new Subject() { Title = "English" };

//    Building fict = new Building() { };
//    Room mathLectureRoom = new Room(fict) { Number = 303 };
//    Room mathPractRoom = new Room(fict) { Number = 428 };
//    Room engLectureRoom = new Room(fict) { Number = 506 };
//    Room englishPractRoom = new Room(fict) { Number = 506 };

//    Lesson math62FirstLecture = new Lesson(math, firstTeacher, it62, mathLectureRoom,
//        Models.Enums.WeekMode.Both, DayOfWeek.Monday, Models.Enums.LessonNumber.First, Models.Enums.LessonType.Lecture);
//    Lesson math62FirstPract = new Lesson(math, firstTeacher, it62, mathPractRoom,
//        Models.Enums.WeekMode.First, DayOfWeek.Monday, Models.Enums.LessonNumber.Second, Models.Enums.LessonType.Practice);

//    Lesson eng62Pract = new Lesson(english, secondTeacher, it62, englishPractRoom,
//        Models.Enums.WeekMode.Second, DayOfWeek.Monday, Models.Enums.LessonNumber.Second, Models.Enums.LessonType.Practice);
//    Lesson eng62Lecture = new Lesson(english, secondTeacher, it62, engLectureRoom,
//        Models.Enums.WeekMode.Both, DayOfWeek.Tuesday, Models.Enums.LessonNumber.First, Models.Enums.LessonType.Lecture);