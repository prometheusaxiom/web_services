﻿namespace ConsumingWebService.Data
{
    public class OpenWeatherMapOptions
    {
        public const string SectionName = "OpenWeatherMap";

        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
    }
}
