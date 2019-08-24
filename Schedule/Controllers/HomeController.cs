using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Schedule.Models.Enums;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Schedule.Models.JsonHelpers;
using Newtonsoft.Json;

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
            return View(await GetAllGroups());
        }
        public async Task<IActionResult> TeacherFind()
        {            
            return View(await GetAllTeachers());
        }

        [HttpPost]
        public IActionResult GroupSchedule(int id)
        {
            var res = GetScheduleForGroup(id);
            return View(res);
        }
        [HttpPost]
        public IActionResult TeacherSchedule(int id)
        {
            var lessons = db.Lessons
               .Include(ls => ls.Group)
               .Include(ls => ls.Teacher)
               .Include(ls => ls.Room)
               .Include(ls => ls.Subject)
               .ToArray()
               .Where(lesson => lesson.Teacher.Id.Equals(id));

            FillViewBag(lessons);
            return View("Schedule", (db.Teachers as IQueryable<Teacher>).FirstOrDefault(teacher => teacher.Id.Equals(id)));
        }

        private void FillViewBag(IEnumerable<Lesson> lessons)
        {
            ViewBag.Days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            ViewBag.Numbers = Enum.GetValues(typeof(LessonNumber)).Cast<LessonNumber>();
            ViewBag.Lessons = lessons;
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

        private async Task<IList<ResponseGroupData>> GetAllGroups()
        {            
            var response = await GetResponse($"{baseUrl}groups");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRoot<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;                
            }
            return null;
        }
        private async Task<IList<ResponseTeacherData>> GetAllTeachers()
        {
            var response = await GetResponse($"{baseUrl}teachers");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRoot<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }

        private async Task<IList<ResponseLessonDataForGroup>> GetScheduleForGroup(int groupId)
        {
            var response = await GetResponse($"{baseUrl}groups/{groupId}/lessons");
            if (response.IsSuccessStatusCode)
            {                
                return JsonConvert.DeserializeObject<ResponseRoot<ResponseLessonDataForGroup>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }
    }
}