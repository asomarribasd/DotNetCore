using System;
using ServerInfoSample.Providers;

namespace ServerInfoSample.Helpers
{
    public class ServerInformation
    {
        public ServerInformation()
        {

        }

        public string Name { set; get; }
        public ServerInformationProvidersType InformationProvider { get; set; }
        public string Information { get; set; }
    }
}
