using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schedule.Models;
using Schedule.Models.Enums;
using Schedule.Models.JsonHelpers;
using Schedule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly DataContext db;
        private readonly string baseUrl = "https://api.rozklad.org.ua/v2/";

        public HomeController(DataContext dataContext, IHttpClientFactory _clientFactory)
        {
            db = dataContext;
            clientFactory = _clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GroupFind()
        {
            return View(new GroupFindViewModel() { Groups = await GetAllGroups() });
        }
        public async Task<IActionResult> TeacherFind()
        {
            var res = await GetAllTeachers();
            return View(new TeacherFindViewModel() { Teachers = res });
        }

        [HttpPost]
        public async Task<IActionResult> GroupSchedule(int id)
        {
            return View(new GroupScheduleViewModel() { Lessons = await GetScheduleForGroup(id), Group = await GetGroup(id) });
        }
        [HttpPost]
        public async Task<IActionResult> TeacherSchedule(int id)
        {
            try
            {
                var res = await GetScheduleForTeacher(id);
                return View(new TeacherScheduleViewModel() { Lessons = res, Teacher = await GetTeacher(id) });
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("Lessons", $"Selected teacher with id #{id} has not lessons");
                return RedirectToAction("TeacherFind");
            }
        }

        private void FillViewBag(IEnumerable<Lesson> lessons)
        {
            ViewBag.Days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            ViewBag.Numbers = Enum.GetValues(typeof(LessonNumber)).Cast<LessonNumber>();
            ViewBag.Lessons = lessons;
        }



        private async Task<ResponseGroupData> GetGroup(int id)
        {
            var response = await GetResponse($"{baseUrl}groups/{id}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentException($"Not found Group with id {id}");
        }
        private async Task<ResponseTeacherData> GetTeacher(int id)
        {
            var response = await GetResponse($"{baseUrl}teachers/{id}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentException($"Not found Teacher with id {id}");
        }

        private async Task<IList<ResponseGroupData>> GetAllGroups()
        {
            var response = await GetResponse($"{baseUrl}groups");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }
        private async Task<IList<ResponseTeacherData>> GetAllTeachers()
        {
            var response = await GetResponse($"{baseUrl}teachers");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }

        private async Task<IList<ResponseLessonDataForGroup>> GetScheduleForGroup(int groupId)
        {
            var response = await GetResponse($"{baseUrl}groups/{groupId}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForGroup>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            return null;
        }
        private async Task<IList<ResponseLessonDataForTeacher>> GetScheduleForTeacher(int teacherId)
        {
            var response = await GetResponse($"{baseUrl}teachers/{teacherId}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForTeacher>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            else
                throw new ArgumentException($"Teacher {teacherId} has not lessons");
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
    }
}