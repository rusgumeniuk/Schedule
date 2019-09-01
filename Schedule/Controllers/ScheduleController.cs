using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using Schedule.Models.JsonHelpers;
using Schedule.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Schedule.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly DataContext db;
        private readonly ResponseFactory responseFactory;

        public ScheduleController(DataContext dataContext, ResponseFactory _responseFactory)
        {
            db = dataContext;
            responseFactory = _responseFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GroupFind()
        {
            return View(new GroupFindViewModel());
        }
        [HttpGet]
        public IActionResult TeacherFind()
        {
            return View(new TeacherFindViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> TeacherFind(string inputedName)
        {
            try
            {
                return View("TeacherSchedule", new TeacherScheduleViewModel()
                {
                    Teacher = await responseFactory.GetTeacher(inputedName),
                    Lessons = await responseFactory.GetScheduleForTeacher(inputedName)
                });//save order!
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("SelectedTeacher", "Перевірте ПІБ викладача або виберіть зі списку");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("SelectedTeacher", $"На даний момент {inputedName} не має навчальних пар");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GroupFind(string inputedName)
        {
            try
            {
                if (!IsFullGroupName(inputedName))
                    throw new ArgumentNullException();
                return View("GroupSchedule", new GroupScheduleViewModel()
                {
                    Group = await responseFactory.GetGroup(inputedName),
                    Lessons = await responseFactory.GetScheduleForGroup(inputedName)
                }); //save order!
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("SelectedGroup", "Перевірте назву введеної групи або виберіть групу зі списку");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("SelectedGroup", $"Вибрана група {inputedName} не має навчальних пар");
            }
            return View();
        }

        private bool IsFullGroupName(string groupName)
        {
            return new Regex(@"^\w{2}-[1-9]{2}", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline).IsMatch(groupName);
        }
    }
}