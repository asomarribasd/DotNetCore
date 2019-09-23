using System;
namespace ServerInfoSample.Providers
{
    public abstract class InformationProviderFactory
    {
        public InformationProviderFactory()
        {
        }

        public abstract GetInformationProvider();
    }
}
