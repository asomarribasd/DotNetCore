using System;
using System.Threading.Tasks;

namespace ServerInfoSample.Providers
{
    public class RDnsServerInformationProvider : ServerInformationProvider
    {
        public RDnsServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override Task<string> GetInformation(string ServerName)
        {
            return Task.FromResult("The information method ReverseDns is not implemented yet.");
        }
    }
}
