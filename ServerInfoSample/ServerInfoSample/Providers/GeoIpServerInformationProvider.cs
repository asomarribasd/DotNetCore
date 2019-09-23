using System;
using System.Threading.Tasks;

namespace ServerInfoSample.Providers
{
    public class GeoIpServerInformationProvider : ServerInformationProvider
    {
        public GeoIpServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override Task<string> GetInformation(string ServerName)
        {
            return Task.FromResult("The information method GeoIp is not implemented yet.");
        }
    }
}
