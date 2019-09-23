using System;
namespace ServerInfoSample.Providers
{
    public class RDnsServerInformationProvider : ServerInformationProvider
    {
        public RDnsServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override string GetInformation(string ServerName)
        {
            throw new NotImplementedException();
        }
    }
}
