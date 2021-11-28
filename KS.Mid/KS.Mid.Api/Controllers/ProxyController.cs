using KS.Mid.Lib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KS.Mid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProxyController> _logger;
        private readonly IHttpClientFactory _httpfactory;

        public ProxyController(ILogger<ProxyController> logger, IHttpClientFactory httpfactory)
        {
            _logger = logger;
            _httpfactory = httpfactory;
        }

        [HttpGet]
        public async Task<IEnumerable<DataInfo>> Get()
        {
            using var http = _httpfactory.CreateClient("MainApi");
            var response = await http.GetAsync("/Home");
            var responseContent = await response.Content.ReadAsStringAsync();
            var z = JsonConvert.DeserializeObject<IEnumerable<DataInfo>>(responseContent);
            z.First().Value += KsData.Val;
            return z;
        }
    }
}
