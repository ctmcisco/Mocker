﻿using Mocker.Application;
using Mocker.Functions.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mocker.Functions.Models
{
    public class HttpRequestProcessor : IHttpRequestProcessor
    {
        private readonly IHttpMockEngine _httpMockEngine;
        private readonly IMapper<HttpRequestObject, Task<HttpRequestDetails>> _mapper;

        public HttpRequestProcessor(IHttpMockEngine httpMockEngine, 
            IMapper<HttpRequestObject, Task<HttpRequestDetails>> mapper)
        {
            _httpMockEngine = httpMockEngine;
            _mapper = mapper;
        }

        public async Task<HttpResponseMessage> ProcessAsync(HttpRequestObject httpRequestObject)
        {
            var httpRequestDetails = await _mapper.Map(httpRequestObject);

            var httpAction = _httpMockEngine.Process(httpRequestDetails);
            var response = new HttpResponseMessage(httpAction.StatusCode)
            {
                Content = new StringContent(httpAction.Body)
            };

            AddHeaders(httpAction.Headers, response);

            return response;
        }

        private void AddHeaders(Dictionary<string, List<string>> headersToAdd, HttpResponseMessage response)
        {
            foreach (var header in headersToAdd)
            {
                response.Content.Headers.Add(header.Key, string.Join(",", header.Value));
            }
        }
    }
}
