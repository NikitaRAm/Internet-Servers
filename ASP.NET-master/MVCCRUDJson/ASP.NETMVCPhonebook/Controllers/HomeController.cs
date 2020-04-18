using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ASP.NETMVCPhonebook.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NETMVCPhonebook.Models;
using Newtonsoft.Json;

namespace ASP.NETMVCPhonebook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<NumbersModel> numbers;
            JsonHelper jh = new JsonHelper();
            numbers = JsonConvert.DeserializeObject<List<NumbersModel>>(jh.Read("phonebook.json", "Data"));
            
            return View(numbers.OrderBy(n => n.Name));
        }

        public IActionResult Add()
        {
            return View("Add");
        }
        
        #region Serialization
        
        private static List<NumbersModel> DeserializeFromJson(JsonHelper helper)
        {
            List<NumbersModel> list = JsonConvert.DeserializeObject < List<NumbersModel>>(helper.Read("phonebook.json", "Data"));
            return list;
        }
        
        private static void SerializeToJson(List<NumbersModel> num, JsonHelper helper)
        {
            string jsonString = JsonConvert.SerializeObject(num);
            helper.Write("phonebook.json", "Data", jsonString);
        }
        
        #endregion
        
        public void ShowInfoById(int id)
        {
            JsonHelper helper = new JsonHelper();
            List<NumbersModel> numbers = DeserializeFromJson(helper);

            var user = numbers.Single(x => x.Id == id);
        
            ViewData["Id"] = user.Id;
            ViewData["Name"] = user.Name;
            ViewData["Surname"] = user.Surname;
            ViewData["Number"] = user.Number;
        }
        
        public IActionResult AddSave(NumbersModel numbersModel)
        {
            List<NumbersModel> numbers;
            JsonHelper helper = new JsonHelper();
            numbers = DeserializeFromJson(helper);

            if (numbers.Count != 0)
            {
                var lastId = numbers.OrderByDescending(x => x.Id).First().Id;
                numbersModel.Id = ++lastId;
            }
            else
            {
                numbersModel.Id = 0;
            }
            
            numbers.Add(numbersModel);

            SerializeToJson(numbers, helper);
            
            return Redirect("Index");
        }

        public IActionResult Update(int id)
        {
            ShowInfoById(id);

            return View("Update");
        }

        public IActionResult UpdateSave(NumbersModel numbersModel)
        {
            List<NumbersModel> numbers;
            JsonHelper helper = new JsonHelper();
            numbers = DeserializeFromJson(helper);

            numbers[numbers.FindIndex(x => x.Id == numbersModel.Id)] = numbersModel;
            
            SerializeToJson(numbers, helper);
            return Redirect("Index");
        }
        
        public IActionResult Delete(int id)
        {
            ShowInfoById(id);

            return View("Delete");
        }

        public IActionResult DeleteSave(NumbersModel numbersModel)
        {
            List<NumbersModel> numbers;
            JsonHelper helper = new JsonHelper();
            numbers = DeserializeFromJson(helper);

            numbers.RemoveAt(numbers.FindIndex(x => x.Id == numbersModel.Id));
            
            SerializeToJson(numbers, helper);
            return Redirect("Index");
        }

    }
    
}