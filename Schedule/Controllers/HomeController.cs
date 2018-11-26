using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using System;
using System.Collections.Generic;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {
            Teacher firstTeacher = new Teacher() { Title = "First Teacher" };
            Teacher secondTeacher = new Teacher() { Title = "Second Teacher" };

            Group firstGroup = new Group() { Title = "First Group" };
            Group it62 = new Group() { Title = "IT-62" };
            Group it52 = new Group() { Title = "IA-52" };

            Subject math = new Subject() { Title = "Math" };
            Subject english = new Subject() { Title = "English" };

            Build fict = new Build() { };
            Room mathLectureRoom = new Room(fict) { Number = 303 };
            Room mathPractRoom = new Room(fict) { Number = 428 };
            Room engLectureRoom = new Room(fict) { Number = 506 };
            Room englishPractRoom = new Room(fict) { Number = 506 };

            Lesson math62FirstLecture = new Lesson(math.Id, firstTeacher.Id, it62.Id, mathLectureRoom.Id,
                Models.Enums.WeekMode.Both, DayOfWeek.Monday, Models.Enums.LessonNumber.First, Models.Enums.LessonType.Lecture);
            Lesson math62FirstPract = new Lesson(math.Id, firstTeacher.Id, it62.Id, mathPractRoom.Id,
                Models.Enums.WeekMode.First, DayOfWeek.Monday, Models.Enums.LessonNumber.Second, Models.Enums.LessonType.Practice);

            Lesson eng62Pract = new Lesson(english.Id, secondTeacher.Id, it62.Id, englishPractRoom.Id,
                Models.Enums.WeekMode.Second, DayOfWeek.Monday, Models.Enums.LessonNumber.Second, Models.Enums.LessonType.Practice);
            Lesson eng62Lecture = new Lesson(english.Id, secondTeacher.Id, it62.Id, engLectureRoom.Id,
                Models.Enums.WeekMode.Both, DayOfWeek.Tuesday, Models.Enums.LessonNumber.First, Models.Enums.LessonType.Lecture);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GroupFind()
        {
            return View(Group.Items.Values);
        }
        public IActionResult TeacherFind()
        {
            return View(Teacher.Items.Values);
        }

        [HttpPost]
        public IActionResult GroupSchedule(Guid id)
        {            
            return View(Group.Items[id]);
        }
        [HttpPost]
        public IActionResult TeacherSchedule(Guid id)
        {
            return View(Teacher.Items[id]);
        }
    }
}