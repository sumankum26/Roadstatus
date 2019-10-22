using Microsoft.Extensions.Configuration;
using NUnit.Framework;         
using RoadStatus;
using System;
using System.IO;
using System.Net.Http;

namespace NUnitTestRoadStatus
{
    [TestFixture]
    public class Tests
    {
        private IConfiguration config;
        public Tests()
        {
            var Configbuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            config = Configbuilder.Build();
        }
        [Test]
        public void ValidRoadIdtest()
        {
            int a=  RoadStatusProgram.callApi("A1");
            Assert.AreEqual(0, a);
        }
        [Test]
        public void InValidRoadIdtest()
        {
            int a = RoadStatusProgram.callApi("A233");
            Assert.AreEqual(1, a);
        }
        [Test]
        public void ValidApiUrl()
        {
            Assert.AreEqual(config["api_url"], "https://api.tfl.gov.uk/Road/");
        }
        [Test]
        public void ValidAppId()
        {
            Assert.AreEqual(config["app_id"], "");  // Input appid
        }

        [Test]
        public void ValidAppKey()
        {
            Assert.AreEqual(config["app_key"], "");  //input app key
        }

        [Test]
        public void InValidApiurl()
        {
            Assert.AreNotEqual(config["api_url"], "any invalid url");
        }

        [Test]
        public void InValidAppId()
        {
            Assert.AreNotEqual(config["app_id"], "any invalid Id");
        }

        [Test]
        public void InValidAppKey()
        {
            Assert.AreNotEqual(config["app_key"], "any invalid key");                  
        }

        [Test]
        public void ValidResponseObject()
        {
            UriBuilder builder = new UriBuilder(config["api_url"] + "A233");
            builder.Query = "app_id=" + config["app_id"] + "&app_key=" + config["app_key"];

            HttpClient client = new HttpClient();
            var result = client.GetAsync(builder.Uri).Result;
            Assert.IsInstanceOf<HttpResponseMessage>(result);
        }
    }
}