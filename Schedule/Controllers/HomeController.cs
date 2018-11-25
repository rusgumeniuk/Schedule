using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using System.Collections.Generic;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly IList<Teacher> Teachers;
        private readonly IList<Group> Groups;

        public HomeController()
        {
            this.Teachers = new List<Teacher>() { new Teacher() { Title = "First Teacher" }, new Teacher() { Title = "Second Teacher" } };
            this.Groups = new List<Group>() { new Group() { Title = "First Group" }, new Group() { Title = "Second Group" } };
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GroupFind()
        {
            return View(this.Groups);
        }
        public IActionResult TeacherFind()
        {
            return View(this.Teachers);
        }

        [HttpPost]
        public IActionResult GroupSchedule(Group group)
        {
            return View(group);
        }
        public IActionResult TeacherSchedule(Teacher teacher)
        {
            return View(teacher);
        }
    }
}