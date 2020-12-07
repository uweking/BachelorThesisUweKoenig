using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_for_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public PingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<string> PostAsync()
        {
            var ret = "";
            //Console.WriteLine("start");
            using (var reader = new StreamReader(Request.Body))
            {
                var reqCL = Request.ContentLength;
                Task<string> preBody = reader.ReadToEndAsync();
                string bodyAsString = await (preBody);
                var body = new StringContent(bodyAsString, Encoding.UTF8, "text/plain");
                //Console.WriteLine("body: " + body);
                var client = _clientFactory.CreateClient();
                var maxCount = 500;
                var wrong = 0;
                Stopwatch stopwatch = new Stopwatch();
                //to get the sopwatch working more acurately a warm up time is suggested 
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < 1500) ;
                stopwatch.Restart();

                for (int i = 0; i < maxCount; i++)
                {
                    var response = await client.PostAsync("http://host.docker.internal:8086/pong", body);//host.docker.internal
                    var contents = await response.Content.ReadAsStringAsync();
                    var resCL = contents.Length;

                    if (reqCL != resCL)
                    {
                        wrong++;
                    }
                }
                stopwatch.Stop();

                return reqCL + "," + stopwatch.ElapsedMilliseconds + "," + wrong;
            }
        }
    }
}