using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerInfoSample.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerInfoSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerInformationController : ControllerBase
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("infoprovider/ippath")]
        public IActionResult IpServerProviders()
        {
            return Ok(EnumExtensions.GetValues<IpServerInfoProviders>());
        }

        [HttpGet]
        [Route("infoproviders/domainserver")]
        public IActionResult DomainServerInfoProviders()
        {
            return Ok(EnumExtensions.GetValues<IpServerInfoProviders>());
        }

        //[HttpPost]
        //[Route("")]
        //public async Task<> 
    }
}

