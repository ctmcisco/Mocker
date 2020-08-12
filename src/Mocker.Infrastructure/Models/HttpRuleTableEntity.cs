﻿using Microsoft.Azure.Cosmos.Table;
using Mocker.Domain.Models.Http;
using System;
using System.Text.Json;

namespace Mocker.Infrastructure.Models
{
    public class HttpRuleTableEntity : TableEntity
    {
        public int Id { get; set; }
        public string? HttpFilterMethod { get; set;  }
        public string? HttpFilterBody { get; set; }
        public string? HttpFilterRoute { get; set; }
        public string? HttpFilterQuery { get; set; }
        public string? HttpFilterHeaders { get; set; }
        public string? HttpActionStatusCode { get; set; }
        public string? HttpActionBody { get; set; }
        public string? HttpActionBodyBlobName { get; set; }
        public string? HttpActionHeaders { get; set; }
        public int HttpActionDelay { get; set; }

        public HttpRuleTableEntity()
        {
        }

        public HttpRuleTableEntity(HttpRule httpRule, int ruleId)
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = Guid.NewGuid().ToString();
            Id = ruleId;
            HttpFilterMethod = httpRule.HttpFilter.Method?.ToString();
            HttpFilterBody = httpRule.HttpFilter.Body;
            HttpFilterRoute = httpRule.HttpFilter.Route;
            HttpFilterQuery = JsonSerializer.Serialize(httpRule.HttpFilter.Query);
            HttpFilterHeaders = JsonSerializer.Serialize(httpRule.HttpFilter.Headers);

            HttpActionStatusCode = httpRule.HttpAction.StatusCode.ToString();
            HttpActionBody = httpRule.HttpAction.Body;
            HttpActionHeaders = JsonSerializer.Serialize(httpRule.HttpAction.Headers);
            HttpActionDelay = httpRule.HttpAction.Delay;
        }
    }
}
