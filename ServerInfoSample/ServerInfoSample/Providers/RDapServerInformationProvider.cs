using System;
using System.Threading.Tasks;

namespace ServerInfoSample.Providers
{
    public class RDapServerInformationProvider : ServerInformationProvider
    {
        public RDapServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override Task<string> GetInformation(string ServerName)
        {
            return Task.FromResult("The information method RDap is not implemented yet.");
        }
    }
}

