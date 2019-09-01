using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseFactory
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly string baseUrl = "https://api.rozklad.org.ua/v2/";

        public ResponseFactory(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<ResponseGroupData> GetGroup(int id)
        {
            var response = await GetResponse($"{baseUrl}groups/{id}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentException($"Not found Group with id {id}");
        }
        public async Task<ResponseGroupData> GetGroup(string name)
        {
            var response = await GetResponse($"{baseUrl}groups/{name}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentNullException($"Not found Group with name {name}");
        }

        public async Task<ResponseTeacherData> GetTeacher(int id)
        {
            var response = await GetResponse($"{baseUrl}teachers/{id}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentException($"Not found Teacher with id {id}");
        }
        public async Task<ResponseLessonData> GetLesson(string groupName, long lessonId)
        {
            var lessons = await GetScheduleForGroup(groupName);            
            return lessons?.FirstOrDefault(lesson => lesson.Id.Equals(lessonId));            
        }

        public async Task<ResponseLessonData> GetLesson(string groupName, string lessonName)
        {
            var lessons = await GetScheduleForGroup(groupName);
            if (lessons == null)
                return null;
            return
                 lessons.FirstOrDefault(lesson => lesson.FullName.Equals(lessonName) || lesson.LessonName.Equals(lessonName)) 
                 ??
                 lessons.FirstOrDefault(lesson => lesson.FullName.Contains(lessonName) || lesson.LessonName.Contains(lessonName));
        }

        public async Task<ResponseTeacherData> GetTeacher(string name)
        {
            var response = await GetResponse($"{baseUrl}teachers/{name}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseRootSingeData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            else
                throw new ArgumentNullException($"Not found Teacher with id {name}");
        }

        public async Task<IList<ResponseGroupData>> GetAllGroups()
        {
            var response = await GetResponse($"{baseUrl}groups");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseGroupData>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }
        public async Task<IList<ResponseTeacherData>> GetAllTeachers()
        {
            var response = await GetResponse($"{baseUrl}teachers");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseTeacherData>>(response.Content.ReadAsStringAsync().Result).Data;
            }
            return null;
        }

        public async Task<IList<ResponseLessonDataForGroup>> GetScheduleForGroup(int groupId)
        {
            var response = await GetResponse($"{baseUrl}groups/{groupId}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForGroup>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            return null;
        }
        public async Task<IList<ResponseLessonDataForGroup>> GetScheduleForGroup(string name)
        {
            var response = await GetResponse($"{baseUrl}groups/{name}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForGroup>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            else
                throw new ArgumentException($"Group {name} has not lessons");
        }
        public async Task<IList<ResponseLessonDataForTeacher>> GetScheduleForTeacher(int teacherId)
        {
            var response = await GetResponse($"{baseUrl}teachers/{teacherId}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForTeacher>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            else
                throw new ArgumentException($"Teacher {teacherId} has not lessons");
        }
        public async Task<IList<ResponseLessonDataForTeacher>> GetScheduleForTeacher(string name)
        {
            var response = await GetResponse($"{baseUrl}teachers/{name}/lessons");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResponseRootMultipleData<ResponseLessonDataForTeacher>>(response.Content.ReadAsStringAsync().Result).Data.OrderBy(lesson => lesson.DayNumber).ThenBy(lesson => lesson.LessonNumber).ToArray();
            }
            else
                throw new ArgumentException($"Teacher {name} has not lessons");
        }

        public async Task<IList<ResponseTeacherData>> GetGroupTeachers(string name)
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
    }
}
