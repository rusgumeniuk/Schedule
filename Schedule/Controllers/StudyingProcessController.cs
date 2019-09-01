using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using Schedule.Models.JsonHelpers;
using Schedule.ViewModels.StudyingProcess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Controllers
{
    [Authorize]
    public class StudyingProcessController : Controller
    {
        private readonly ResponseFactory responseFactory;
        private readonly UserManager<User> userManager;

        public StudyingProcessController(UserManager<User> _userManager, ResponseFactory factory)
        {
            userManager = _userManager;
            responseFactory = factory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Teachers()
        {
            User user = await userManager.GetUserAsync(HttpContext.User);
            return View(await responseFactory.GetGroupTeachers(user.GroupName));
        }
        public async Task<IActionResult> Lessons()
        {
            User user = await userManager.GetUserAsync(HttpContext.User);
            return View(await responseFactory.GetScheduleForGroup(user.GroupName));
        }

        public async Task<IActionResult> Lesson(string lessonName)
        {
            var user = await GetCurrentUser();
            var lesson = await responseFactory.GetLesson(user.GroupName, lessonName);
            IList<LessonFeedback> list = new List<LessonFeedback>
            {
                new LessonFeedback() { Description = "Pretty good lesson", Lesson = lesson, User = user, Rate = Models.Enums.Rate.Normal },
                new LessonFeedback() { Description = "So cool lesson. Like him", Lesson = lesson, User = user, Rate = Models.Enums.Rate.VeryWell }
            };
            return View(new LessonFeedbackViewModel() { CurrentUser = user, Lesson = lesson, LessonFeedbacks = list });
        }

        public async Task<IActionResult> Teacher(string teacherName)
        {
            var user = await GetCurrentUser();
            var teacher = await responseFactory.GetTeacher(teacherName);
            IList<TeacherFeedback> list = new List<TeacherFeedback>
            {
                new TeacherFeedback() { Description = "Pretty good teacher", Teacher = teacher, User = user, Rate = Models.Enums.Rate.Normal },
                new TeacherFeedback() { Description = "So cool teacher. Like him", Teacher = teacher, User = user, Rate = Models.Enums.Rate.VeryWell }
            };
            return View(new TeacherFeedbackViewModel() { CurrentUser = user, Teacher = teacher, TeacherFeedbacks = list });
        }

        public async Task<IActionResult> LeaveTeacherFeedback(LeaveTeacherFeedbackViewModel model)
        {
            TeacherFeedback feedback = new TeacherFeedback()
            {
                Teacher = await responseFactory.GetTeacher(model.TeacherName),
                User = model.IsAnonymus ? null : await GetCurrentUser(),
                Rate = model.Rate,
                Description = model.Feedback
            };
            return RedirectToAction("Teacher", new { teacherName = model.TeacherName });
        }
        public async Task<IActionResult> LeaveLessonFeedback(LeaveLessonFeedbackViewModel model)
        {
            var user = await GetCurrentUser();
            LessonFeedback feedback = new LessonFeedback()
            {
                Lesson = await responseFactory.GetLesson(user.GroupName, model.LessonName),
                User = model.IsAnonymus ? null : user,
                Rate = model.Rate,
                Description = model.Feedback
            };
            return RedirectToAction("Lesson", new { lessonName = model.LessonName });
        }

        private async Task<User> GetCurrentUser()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }
    }
}