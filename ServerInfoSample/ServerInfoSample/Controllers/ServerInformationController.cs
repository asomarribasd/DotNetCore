using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerInfoSample.Helpers;
using ServerInfoSample.Providers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerInfoSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerInformationController : Controller
    {

        private readonly ILogger<ServerInformationController> _logger;

        public ServerInformationController(ILogger<ServerInformationController> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("InformationProviders")]
        public IActionResult InformationServerProviders()
        {
            return Ok(EnumExtensions.GetValues<ServerInformationProvidersType>());
        }

        [HttpGet]
        [Route("ServerInformation")]
        public async Task<ServerInformation> ServerInformation(string Name, ServerInformationProvidersType Provider)
        {




            return new ServerInformation();
        }

        [HttpGet]
        [Route("informationlist/{Name}/{Providers?}")]
        public async Task<List<ServerInformation>> ServerInformationList(string Name, List<ServerInformationProvidersType> Providers)
        {

            List<ServerInformation> serversInformation = new List<ServerInformation>();
            InformationProviderFactory factory = null;

            foreach (ServerInformationProvidersType provider in Providers)
            {
                switch (provider)
                {
                    case ServerInformationProvidersType.GeoIp:
                        factory = new GeoIpInformationProviderFactory();
                        break;
                    case ServerInformationProvidersType.RDap:
                        factory = new RDapInformationProviderFactory();
                        break;
                    case ServerInformationProvidersType.ReverseDNS:
                        factory = new RDnsInformationProviderFactory();
                        break;
                    case ServerInformationProvidersType.Ping:
                        factory = new PingInformationProviderFactory();
                        break;
                    default:
                        break;
                }
                ServerInformation information = new ServerInformation();
                ServerInformationProvider informationProvider = factory.GetInformationProvider();

                information.Name = Name;
                information.InformationProvider = provider;
                information.Information = await informationProvider.GetInformation(Name);

                serversInformation.Add(information);
            }

            return serversInformation;

        }

        
    }
}

