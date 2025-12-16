using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProiectSCD
{
    public class DepartmentService
    {
        private readonly HttpClient client;

        public DepartmentService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Doctor> GetBusyDoctors()
        {
            HttpResponseMessage response = client.GetAsync("doctors/busy").Result;

            if (!response.IsSuccessStatusCode)
                return new List<Doctor>();

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Doctor>>(json) ?? new List<Doctor>();
        }

        public List<Doctor> GetAllDoctors()
        {
            HttpResponseMessage response = client.GetAsync("doctors").Result;

            if (!response.IsSuccessStatusCode)
                return new List<Doctor>();

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Doctor>>(json) ?? new List<Doctor>();
        }

    }
}
