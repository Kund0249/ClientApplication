using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApplication.Models;
using System.Web.Script.Serialization;

namespace ClientApplication.Controllers
{
    public class DepartmentController : Controller
    {
        string BaseUrl = "http://localhost:54270/api/";
        // GET: Department
        public async Task<ActionResult> Index()
        {
            string EndPoint = BaseUrl + "department";
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = await client.GetAsync(EndPoint);

            if (httpResponse.IsSuccessStatusCode)
            {
                string data = await httpResponse.Content.ReadAsStringAsync();
                JavaScriptSerializer javaScript = new JavaScriptSerializer();
                var listdata = javaScript.Deserialize<List<DepartmentModel>>(data);
                return View(listdata);
            }

            return null;
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(DepartmentModel model)
        {
            string EndPoint = BaseUrl + "department";
            HttpClient client = new HttpClient();

            JavaScriptSerializer javaScript = new JavaScriptSerializer();
            var Jsondata = javaScript.Serialize(model);
            var stringcontent = new StringContent(Jsondata, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await client.PostAsync(EndPoint, stringcontent);

            if (httpResponse.IsSuccessStatusCode)
            {

            }
            return RedirectToAction("Index");
        }
    }
}