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
        [Route("infoprovider")]
        public IActionResult InfoServerProviders()
        {
            return Ok(EnumExtensions.GetValues<ServerInformationProvidersType>());
        }


        [HttpPost]
        [Route("informationlist/{Name}/{Providers}")]
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

