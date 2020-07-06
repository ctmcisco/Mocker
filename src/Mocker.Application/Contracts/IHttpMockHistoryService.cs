﻿using Mocker.Application.Models;
using Mocker.Domain.Models.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mocker.Application.Contracts
{
    public interface IHttpMockHistoryService
    {
        Task AddAsync(HttpRequestDetails httpRequestDetails);

        Task<List<HttpRequestDetails>> FindAsync(HttpMockHistoryFilter httpMockHistoryFilter);

        Task DeleteAllAsync();
    }
}