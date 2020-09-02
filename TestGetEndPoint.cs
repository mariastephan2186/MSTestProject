using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Json.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestProject.RestSharpGetEndPoint.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MSTestProject.RestGetEndPoint
{

    [TestClass]
    public class TestGetEndPoint
    {

        private string getUrl = "http://bpdts-test-app-v2.herokuapp.com/users";
        private string EndPoint1 = "http://bpdts-test-app-v2.herokuapp.com/user/{id}";
        private string EndPoint2 = "http://bpdts-test-app-v2.herokuapp.com/city/{city}/users";


        [TestMethod]
        public void TestGetUsingRestSharp()

        {



            IRestClient restClient = new RestClient();

            IRestRequest restRequest1 = new RestRequest(getUrl);
            restRequest1.AddHeader("Accept", "application/json");
            IRestResponse restResponse1 = restClient.Get(restRequest1);

            IRestRequest restRequest2 = new RestRequest("users/{id}", Method.GET);
            restRequest2.AddUrlSegment("id", 1);
            restRequest2.AddHeader("Accept", "application/json");
            IRestResponse restResponse2 = restClient.Get(restRequest2);

            IRestRequest restRequest3 = new RestRequest("city/{city}/users", Method.GET);
            restRequest2.AddUrlSegment("city", "Kax");
            restRequest3.AddHeader("Accept", "application/json");
            IRestResponse restResponse3 = restClient.Get(restRequest3);




        }




        [TestMethod]
        //Verifying the Status Code for BaseUrl
        public void TestStatusCodeBaseUrl()

        {
            IRestClient restClient = new RestClient();

            IRestRequest restRequest1 = new RestRequest(getUrl);
            restRequest1.AddHeader("Accept", "application/json");
            IRestResponse<List<JSONRootObject>> restResponse1 = restClient.Get<List<JSONRootObject>>(restRequest1);

            if (restResponse1.IsSuccessful)

            {
                Console.WriteLine("Status code is " + restResponse1.StatusCode);

                Console.WriteLine("Size of the list is  " + restResponse1.Data.Count);
                HttpStatusCode statuscode = restResponse1.StatusCode;

                Console.WriteLine("Status Message => " + statuscode);
                Console.WriteLine("Status Code  =>" + (int)statuscode);
                Assert.AreEqual(200, (int)restResponse1.StatusCode);
                Assert.AreEqual("OK", (string)restResponse1.StatusDescription);

                Console.WriteLine("StatusDescription" + restResponse1.StatusDescription);
                Assert.AreEqual("OK", (string)restResponse1.StatusDescription);

            }

            else
            {
                Console.WriteLine("Error mesage  is " + restResponse1.ErrorMessage);
                Console.WriteLine("Stack trace  is " + restResponse1.ErrorException);


            }







        }

        [TestMethod]
        //Verifying the Status Code for First Endpoint - /user/{id}
        public void TestStatusCodeFirstEndPoint()

        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest2 = new RestRequest(EndPoint1);

            // IRestRequest restRequest2 = new RestRequest("/user/{id}", Method.GET);

            restRequest2.AddUrlSegment("id", 2);
            restRequest2.AddHeader("Accept", "application/json");
  IRestResponse<List<JSONRootObject>> restResponse2 = restClient.Get<List<JSONRootObject>>(restRequest2);

            if (restResponse2.IsSuccessful)

            {
                Console.WriteLine("Status code is "+restResponse2.StatusCode);

                Console.WriteLine("Size of the list is  " + restResponse2.Data.Count);
                HttpStatusCode statuscode = restResponse2.StatusCode;

                Console.WriteLine("Status Message => " + statuscode);
                Console.WriteLine("Status Code  =>" + (int)statuscode);
                Assert.AreEqual(200, (int)restResponse2.StatusCode);
                Assert.AreEqual("OK", (string)restResponse2.StatusDescription);

                Console.WriteLine("StatusDescription" + restResponse2.StatusDescription);
                Assert.AreEqual("OK", (string)restResponse2.StatusDescription);

            }

            else
            {
                Console.WriteLine("Error mesage  is " + restResponse2.ErrorMessage);
                Console.WriteLine("Stack trace  is " + restResponse2.ErrorException);


            }

           

         

            






        }
        [TestMethod]

        //Verifying the Status Code for Second endpoint -city/{city}/users
        public void TestStatusCodeSecondEndPoint()

        {
            IRestClient restClient = new RestClient();

            IRestRequest restRequest3 = new RestRequest(EndPoint2);
            // restRequest3 = new RestRequest("city/{city}/users", Method.GET);
            restRequest3.AddUrlSegment("city", "Kax");
            restRequest3.AddHeader("Accept", "application/json");
            IRestResponse<List<JSONRootObject>> restResponse3 = restClient.Get<List<JSONRootObject>>(restRequest3);

            if (restResponse3.IsSuccessful)

            {
                Console.WriteLine("Status code is " + restResponse3.StatusCode);
                Console.WriteLine("Json content is  " + restResponse3.Content);

                Console.WriteLine("Size of the list is  " + restResponse3.Data.Count);
                HttpStatusCode statuscode = restResponse3.StatusCode;

                Console.WriteLine("Status Message => " + statuscode);
                Console.WriteLine("Status Code  =>" + (int)statuscode);
                Assert.AreEqual(200, (int)restResponse3.StatusCode);
                Assert.AreEqual("OK", (string)restResponse3.StatusDescription);

                Console.WriteLine("StatusDescription" + restResponse3.StatusDescription);
                Assert.AreEqual("OK", (string)restResponse3.StatusDescription);
                JToken expected = JToken.Parse(@"[{""id"":1,""first_name"":""Maurise"",""last_name"":""Shieldon"",""email"":""mshieldon0@squidoo.com"",""ip_address"":""192.57.232.111"",""latitude"":34.003135,""longitude"":-117.7228641},{""id"":854,""first_name"":""Nelly"",""last_name"":""Thurley"",""email"":""nthurleynp@joomla.org"",""ip_address"":""46.72.120.66"",""latitude"":34.003135,""longitude"":-117.7228641}]");

            Assert.AreEqual(expected,restResponse3.Content,"compared");    
            }

            else
            {
                Console.WriteLine("Error mesage  is " + restResponse3.ErrorMessage);
                Console.WriteLine("Stack trace  is " + restResponse3.ErrorException);


            }


           


        }

       

        }
    }

