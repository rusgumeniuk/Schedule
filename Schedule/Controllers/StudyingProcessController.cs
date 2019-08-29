using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schedule.Models;
using Schedule.Models.JsonHelpers;
using Schedule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Schedule.Controllers
{
    [Authorize]
    public class StudyingProcessController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly UserManager<User> userManager;
        private readonly string baseUrl = "https://api.rozklad.org.ua/v2/";
        public StudyingProcessController(IHttpClientFactory _httpClientFactory, UserManager<User> _userManager)
        {
            clientFactory = _httpClientFactory;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Teachers()
        {
            User user = await userManager.GetUserAsync(HttpContext.User);
            return View(await GetGroupTeachers(user.GroupName));
        }


        public async Task<IActionResult> Teacher(string teacherName)
        {
            var user = await GetCurrentUser();
            var teacher = await GetTeacher(teacherName);
            IList<TeacherFeedback> list = new List<TeacherFeedback>();
            list.Add(new TeacherFeedback() { Description = "Pretty good teacher", Teacher = teacher, User = user, Rate = Models.Enums.Rate.Normal });
            list.Add(new TeacherFeedback() { Description = "So cool teacher. Like him", Teacher = teacher, User = user, Rate = Models.Enums.Rate.VeryWell});
            return View(new TeacherFeedbackViewModel() { CurrentUser = user, Teacher = teacher, TeacherFeedbacks = list });
        }

        public async Task<IActionResult> LeaveTeacherFeedback(LeaveTeacherFeedbackViewModel model)
        {
            TeacherFeedback feedback = new TeacherFeedback()
            {
                Teacher = await GetTeacher(model.TeacherName),
                User = model.IsAnonymus ? null : await GetCurrentUser(),
                Rate = model.Rate,
                Description = model.Feedback
            };
            return RedirectToAction("Teacher", new { teacherName = model.TeacherName });
        }

        private async Task<ResponseTeacherData> GetTeacher(string name)
        {
            var response = await GetResponse($"{baseUrl}teachers/{name}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentNullException($"Not found Teacher with id {name}");
        }

        private async Task<IList<ResponseTeacherData>> GetGroupTeachers(string name)
        {
            var response = await GetResponse($"{baseUrl}groups/{name}/teachers");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data.ToArray();
            }
            else
                throw new ArgumentException($"Group {name} has not lessons");
        }

        private async Task<HttpResponseMessage> GetResponse(string requestUrl)
        {
            var request = new HttpRequestMessage(
               HttpMethod.Get,
               requestUrl
               );
            using (var client = clientFactory.CreateClient())
            {
                return await client.SendAsync(request);
            }
        }

        private async Task<User> GetCurrentUser()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }
    }
}