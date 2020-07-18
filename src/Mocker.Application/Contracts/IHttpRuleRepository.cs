﻿using Mocker.Domain.Models.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mocker.Application.Contracts
{
    public interface IHttpRuleRepository
    {
        Task AddAsync(HttpRule httpRule);

        Task DeleteAllAsync();

        Task<List<HttpRule>> GetAllAsync();

        Task<List<HttpRule>> FindAsync(HttpMethod httpMethod, string? body, string? route);
    }
}