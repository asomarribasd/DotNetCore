using System;

namespace ServerInfoSample.Providers
{
    public class RDapServerInformationProvider : ServerInformationProvider
    {
        public RDapServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override string GetInformation(string ServerName)
        {
            throw new NotImplementedException();
        }
    }
}

