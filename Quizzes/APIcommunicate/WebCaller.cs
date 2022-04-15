using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Threading.Tasks;

namespace Quizzes.APIcommunicate
{
    public class WebCaller : HttpClient
    {
        public WebCaller()
        {
            base.BaseAddress = new Uri("https://localhost:7110/");
            base.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public  string WebCall(string APIpath)
        {
            var ser = new JavaScriptSerializer();
            HttpResponseMessage resp = base.GetAsync(APIpath).Result;
            string som =  resp.Content.ReadAsStringAsync().Result;
            return som;
        }
        //query specific data
        public string Getdata(string apiPath, string data)
        {

            string s = "";
            try
            {
                var resp = base.PostAsync(apiPath, new StringContent(data, Encoding.UTF8, "application/json")).Result;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    //s = resp.Content.ReadAsAsync<string>().Result;
                    s = resp.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    s = "[]";
                }
            }
            catch (Exception ex)
            {
                s = "[]";
            }

            return s;
        }
        public void InsertData(string apiPath, string data)
        {
            try
            {
                var resp = base.PostAsync(apiPath, new StringContent(data, Encoding.UTF8, "application/json")).Result;
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
