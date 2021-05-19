using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASapp.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 60)]
        public string Index()
        {

            return $"Hi! {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}";
        }


        [HttpGet]
        [ResponseCache(Duration = 1000000)]
        public string GetUser(string username)
        {

            return $"Hi! UserName {username};   {DateTime.Now.ToString()}";
        }


        public string Add(object animal)
        {
            DateTime x = new DateTime();
            x.Add((TimeSpan)animal);
            return x.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}
