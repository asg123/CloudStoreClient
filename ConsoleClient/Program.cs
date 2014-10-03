using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ServMan.ApiV1.Models;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string uri = "http://localhost/CloudFactoryStore/api/v1/User";
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            //this is the default method/verb, but it's here for clarity
            webRequest.Headers["CS-TokenAuth-UserId"] = "00000000-0000-0000-0000-000000000001";
            webRequest.Headers["CS-TokenAuth-Secret"] = "**DONT_TELL_ANYONE!**";
            webRequest.ContentType = "application/json";
            webRequest.Headers["CS-TokenAuth-OrganizationId"] = "00000000-0000-0000-0000-000000000002";
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            Console.WriteLine("Response returned with status code of {0}", webResponse.StatusCode);
            Console.WriteLine("**************************\nResponse text:");
            using (var reader = new StreamReader(webResponse.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();
                Console.WriteLine(objText);
                var usrs = JsonConvert.DeserializeObject<User[]>(objText);
                Console.WriteLine("**************************\nUser names:");
                foreach (var u in usrs)
                {
                    Console.WriteLine(u.Login);
                }
            }

        }
    }
}
