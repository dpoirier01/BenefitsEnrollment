using Paylocity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Paylocity.Business
{
    public class BenefitService : IDisposable
    {

        string baseUrl = "http://localhost:58843/api/Benefits/";
        HttpClient client;

        public BenefitService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("GetEmployees").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result.ToList();
            }
            catch (HttpRequestException ex)
            {

            }
            return null;
        }

        public HttpResponseMessage CreateDependent(Dependent dependent)
        {

            HttpResponseMessage response = client.PostAsJsonAsync("CreateDependent", dependent).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<HttpResponseMessage>().Result;
            }
            return null;
        }

        public int CreateEmployee(Employee employee)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("CreateEmployee", employee).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<int>().Result;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return 0;
        }

        public BenefitsEnrollment GetBenefitsEnrollment(int empId)
        {
            string param = "";
            param = string.Format("/{0}", empId.ToString());
            try
            {
                HttpResponseMessage response = client.GetAsync("BenefitsEnrollment" + param).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<BenefitsEnrollment>().Result;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return null;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
