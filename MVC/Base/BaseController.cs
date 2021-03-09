﻿using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Base
{
    public class BaseController<Entity, Key> : Controller
    {
        private readonly HttpClient httpClient;

        public BaseController()
        {
            URL url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(url.GetDevelopment())
            };
        }

        public ViewResult Index() => View();

        public async Task<JsonResult> Get()
        {
            var response = await httpClient.GetAsync(typeof(Entity).Name);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Entity>>>(apiResponse);
            return new JsonResult(result);
        }

        public async Task<JsonResult> GetById(Key key)
        {
            var response = await httpClient.GetAsync(typeof(Entity).Name + "/" + key);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> Post(Entity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(typeof(Entity).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Entity>(apiResponse);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> Put(Entity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(Entity).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(Key key)
        {
            using var response = await httpClient.DeleteAsync(typeof(Entity).Name + '/' + key);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);
            return Json(result);
        }
    }
}
