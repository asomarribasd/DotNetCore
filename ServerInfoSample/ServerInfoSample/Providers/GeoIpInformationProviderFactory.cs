﻿using System;
namespace ServerInfoSample.Providers
{
    public class GeoIpInformationProviderFactory : InformationProviderFactory
    {
        public GeoIpInformationProviderFactory()
        {
        }

        public override ServerInformationProvider GetInformationProvider()
        {
            throw new NotImplementedException();
        }
    }
}
