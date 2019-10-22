using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace RoadStatus
{
    public class RoadStatusProgram
    {
        static int Main(string[] args)
        {     

            if(args.Length != 0)
            {
                return Environment.ExitCode = callApi(args[0]);  // return exit code 
            }
            else
            {
                Console.WriteLine("Command line argument is mandatory");
                return 1; 
            }
        }

        public static int callApi(string argument)
        {
            // Read configuration like app_url,app_id and app_key from appsetting.json

            var Configbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = Configbuilder.Build();
            UriBuilder builder = new UriBuilder(config["api_url"] + argument);
            builder.Query = "app_id=" + config["app_id"] + "&app_key=" + config["app_key"];

            HttpClient client = new HttpClient();
            try
            {
                //call api
                var result = client.GetAsync(builder.Uri).Result;

                if (result.StatusCode == HttpStatusCode.OK)  //check the http status code is 200
                {
                    var response = JsonConvert.DeserializeObject<List<Response>>(result.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("The status of the " + response[0].displayName + " is as follows");
                    Console.WriteLine("Road Status is " + response[0].statusSeverity);
                    Console.WriteLine("Road Status Description is " + response[0].statusSeverityDescription);
                    return 0;
                }
                else
                {
                    Console.WriteLine(argument + " is not a valid road");  // road not found or invalid road
                    return 1;
                }
            }
            catch (Exception exObj)  // incase of any exception occurs
            {
                Console.WriteLine("Exception occured" + exObj.Message);
                return 1;
            }
            
        }
    }
}
