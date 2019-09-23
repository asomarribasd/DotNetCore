using System;
using System.Threading.Tasks;

namespace ServerInfoSample.Providers
{
    public class PingServerInformationProvider : ServerInformationProvider
    {
        public PingServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override Task<string> GetInformation(string ServerName)
        {
            return Task.FromResult("The information method Ping is not implemented yet.");
        }
    }
}
