using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerInfoSample.Helpers;
using ServerInfoSample.Providers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerInfoSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerInformationController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("infoprovider/ippath")]
        public IActionResult InfoServerProviders()
        {
            return Ok(EnumExtensions.GetValues<ServerInformationProvidersType>());
        }


        [HttpPost]
        [Route("")]
        public async Task<List<ServerInformation>> GetServerInformation(string Name, ServerInformationProvidersType Provider)
        {
            return new List<ServerInformation>();
        }

        [HttpPost]
        [Route("")]
        public async Task<List<ServerInformation>> GetServerInformationList(string Name, List<ServerInformationProvidersType> Provider)
        {
            return new List<ServerInformation>();
        }

    }
}

