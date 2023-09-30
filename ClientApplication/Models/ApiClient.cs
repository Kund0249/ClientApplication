using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace ClientApplication.Models
{

    public class ApiClient
    {
        string BaseUrl = "http://localhost:54270/api/";

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            try
            {
                HttpClient client = new HttpClient();
                string EndPoint = BaseUrl + "department";

                HttpResponseMessage httpResponse = await client.GetAsync(EndPoint);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string data = await httpResponse.Content.ReadAsStringAsync();
                    JavaScriptSerializer javaScript = new JavaScriptSerializer();
                    var listdata = javaScript.ConvertToType<List<DepartmentModel>>(javaScript);
                    return listdata;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}