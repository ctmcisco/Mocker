﻿using Mocker.Application.Contracts;
using Mocker.Domain.Models.Http;
using Mocker.Application.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mocker.Application.Services
{
    public class HttpRuleEngine : IHttpRuleEngine
    {
        private readonly IHttpRuleRepository _httpRuleRepository;

        public HttpRuleEngine(IHttpRuleRepository httpRuleRepository)
        {
            _httpRuleRepository = httpRuleRepository;
        }

        public async Task<HttpAction> Process(HttpRequestDetails httpRequestDetails) => (await _httpRuleRepository.GetAllAsync())
                .Where(r => IsNullOrMatchingMethod(r, httpRequestDetails)
                    && IsNullOrMatchingBody(r, httpRequestDetails)
                    && IsNullOrMatchingRoute(r, httpRequestDetails)
                    && IsNullOrMatchingHeader(r, httpRequestDetails)
                    && IsNullOrMatchingQuery(r, httpRequestDetails)
                ).FirstOrDefault()?
                .HttpAction ?? BuildDefaultHttpAction();

        private bool IsNullOrMatchingMethod(HttpRule rule, HttpRequestDetails httpRequestDetails) => 
            rule.HttpFilter.Method == null || rule.HttpFilter.Method == httpRequestDetails.Method;
        
        private bool IsNullOrMatchingBody(HttpRule rule, HttpRequestDetails httpRequestDetails) => 
            rule.HttpFilter.Body == null || rule.HttpFilter.Body == httpRequestDetails.Body;

        private bool IsNullOrMatchingRoute(HttpRule rule, HttpRequestDetails httpRequestDetails) =>
            rule.HttpFilter.Route == null || rule.HttpFilter.Route == httpRequestDetails.Route;

        private bool IsNullOrMatchingHeader(HttpRule rule, HttpRequestDetails httpRequestDetails) =>
            rule.HttpFilter.Headers == null || rule.HttpFilter.Headers.EqualIgnoringOrder(httpRequestDetails.Headers);
        
        private bool IsNullOrMatchingQuery(HttpRule rule, HttpRequestDetails httpRequestDetails) =>
            rule.HttpFilter.Query == null || rule.HttpFilter.Query.Equals(httpRequestDetails.Query);

        private HttpAction BuildDefaultHttpAction() => new HttpAction(HttpStatusCode.OK, string.Empty);
    }
}
