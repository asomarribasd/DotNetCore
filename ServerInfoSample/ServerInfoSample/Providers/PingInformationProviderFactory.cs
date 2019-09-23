using System;
namespace ServerInfoSample.Providers
{
    public class PingInformationProviderFactory : InformationProviderFactory
    {
        public PingInformationProviderFactory()
        {
        }

        public override ServerInformationProvider GetInformationProvider()
        {
            throw new NotImplementedException();
        }
    }
}
