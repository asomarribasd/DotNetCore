using System;

namespace ServerInfoSample.Helpers
{
    public class ServerInformation
    {
        public ServerInformation()
        {

        }

        public string Name { set; get; }
        public ServerInformationProviders InformationProvider { get; set; }
        public string Information { get; set; }
    }
}
