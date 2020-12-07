using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PingPongReal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PongController : ControllerBase
    {
        [HttpPost]
        public Task<String> PostAsync()
        {
            var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEndAsync();
            return body;
        }
    }
}