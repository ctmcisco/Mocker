﻿using Mocker.Domain;
using System.Collections.Generic;
using System.Net.Http;

namespace Mocker.Infrastructure
{
    public interface IMockHttpRuleRepository
    {
        List<HttpMockRule> Mocks { get; }

        void Add(HttpMockRule mock);

        void Remove(HttpMockRule mock);

        IEnumerable<HttpMockRule> GetAll();
        
        IEnumerable<HttpMockRule> Find(HttpMethod httpMethod, IDictionary<string, string> queryString, 
            string body, string route);
    }
}