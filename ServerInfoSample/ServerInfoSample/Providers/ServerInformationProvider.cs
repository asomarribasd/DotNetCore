using System;

namespace ServerInfoSample.Providers
{
    public abstract class ServerInformationProvider
    {
        public ServerInformationProvider()
        {

        }

        public abstract ServerInformationProvidersType ProviderType { get; }
    }
}
