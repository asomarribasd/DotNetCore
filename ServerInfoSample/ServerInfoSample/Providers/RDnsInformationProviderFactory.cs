using System;
namespace ServerInfoSample.Providers
{
    public class RDnsInformationProviderFactory : InformationProviderFactory
    {
        public RDnsInformationProviderFactory()
        {
        }

        public override ServerInformationProvider GetInformationProvider()
        {
            throw new NotImplementedException();
        }
    }
}
