using System;
using System.Threading.Tasks;

namespace ServerInfoSample.Providers
{
    public abstract class ServerInformationProvider
    {
        public ServerInformationProvider()
        {

        }

        public abstract ServerInformationProvidersType ProviderType { get; }

        public abstract Task <string> GetInformation(String ServerName);
    }
}
