using System;
namespace ServerInfoSample.Providers
{
    public class PingServerInformationProvider : ServerInformationProvider
    {
        public PingServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override string GetInformation(string ServerName)
        {
            throw new NotImplementedException();
        }
    }
}
