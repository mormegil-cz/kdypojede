using System;

namespace GolemioApi
{
    public class GolemioConfiguration
    {
        public string UserAgent { get; }
        public string? From { get; }
        public string ApiKey { get; }
        public Uri ApiServerBase { get; }

        public GolemioConfiguration(string userAgent, string? from, string apiKey, Uri apiServerBase)
        {
            UserAgent = userAgent;
            From = from;
            ApiKey = apiKey;
            ApiServerBase = apiServerBase;
        }
    }
}