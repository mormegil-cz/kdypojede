using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace GolemioApi
{
    public static class ApiClient
    {
        public static Task<T> Get<T>(GolemioConfiguration configuration, string apiPath, Dictionary<string, object?> query)
        {
            var url = new Url(configuration.ApiServerBase)
                .AppendPathSegment(apiPath)
                .WithHeader("Accept", "application/json");
            foreach (var param in query)
            {
                url.SetQueryParam(param.Key, param.Value);
            }

            void AddHeader(string header, string? value)
            {
                if (!String.IsNullOrEmpty(value)) url.WithHeader(header, value);
            }

            AddHeader("User-Agent", configuration.UserAgent);
            AddHeader("From", configuration.From);
            AddHeader("X-Access-Token", configuration.ApiKey);

            return url.GetJsonAsync<T>();
        }
    }
}