﻿using System;
namespace ServerInfoSample.Providers
{
    public class GeoIpServerInformationProvider : ServerInformationProvider
    {
        public GeoIpServerInformationProvider()
        {
        }

        public override ServerInformationProvidersType ProviderType => throw new NotImplementedException();

        public override string GetInformation(string ServerName)
        {
            throw new NotImplementedException();
        }
    }
}
