﻿using Mocker.Application.Contracts;
using Mocker.Application.Services;
using Mocker.Domain.Models.Http;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Mocker.Application.Tests.Unit
{
    public class HttpRuleServiceTests
    {
        private readonly Mock<IHttpRuleRepository> _mockHttpRuleRepository = new Mock<IHttpRuleRepository>();
        private readonly HttpRuleService _sut;

        public HttpRuleServiceTests()
        {
            _sut = new HttpRuleService(_mockHttpRuleRepository.Object);
        }

        [Fact]
        public async Task AddsRule()
        {

            var httpRule = BuildHttpRule();
            await _sut.AddAsync(httpRule);

            _mockHttpRuleRepository.Verify(m => m.AddAsync(It.Is<HttpRule>(h => h == httpRule)));
        }

        
        [Fact]
        public async Task RemovesAllRules()
        {
            await _sut.RemoveAllAsync();

            _mockHttpRuleRepository.Verify(m => m.RemoveAllAsync());
        }

        [Fact]
        public async Task GetsAllRules()
        {
            _mockHttpRuleRepository.Setup(m => m.GetCachedRulesAsync()).Returns(Task.FromResult(
                (IEnumerable<HttpRule>) new List<HttpRule> { BuildHttpRule() }));
            SetUpRuleDetailsMock();

            var rules = await _sut.GetAllAsync();

            _mockHttpRuleRepository.Verify(m => m.GetCachedRulesAsync());

            Assert.Single(rules);
            Assert.Contains(rules, r => r.HttpFilter.Body == "Hello world!");
            Assert.Contains(rules, r => r.HttpAction.Body == "Hi back!");
        }

        [Fact]
        public async Task GetsAllRuleFullDetails()
        {
            _mockHttpRuleRepository.Setup(m => m.GetCachedRulesAsync()).Returns(Task.FromResult(
                (IEnumerable<HttpRule>)new List<HttpRule> { BuildHttpRulePartiallyCached() }));
            SetUpRuleDetailsMock();

            var rules = await _sut.GetAllAsync();

            _mockHttpRuleRepository.Verify(m => m.GetCachedRulesAsync());
            _mockHttpRuleRepository.Verify(m => m.GetRuleDetailsAsync(It.IsAny<int>()));

            Assert.Single(rules);
            Assert.Contains(rules, r => r.HttpFilter.Body == "Hello world!");
            Assert.Contains(rules, r => r.HttpAction.Body == "Hi back!");
        }

        private void SetUpRuleDetailsMock() => _mockHttpRuleRepository.Setup(m => m.GetRuleDetailsAsync(It.Is<int>(i => i == 1)))
            .Returns(Task.FromResult<HttpRule?>(BuildHttpRule()));
        private static HttpRule BuildHttpRule()
        {
            var httpFilter = new HttpFilter(HttpMethod.Get, "Hello world!");
            var httpAction = new HttpAction(HttpStatusCode.OK, "Hi back!");
            var httpRule = new HttpRule(httpFilter, httpAction, 1);
            return httpRule;
        }

        private static HttpRule BuildHttpRulePartiallyCached()
        {
            var httpFilter = new HttpFilter(HttpMethod.Get, "Hello world!");
            var httpAction = new HttpAction(HttpStatusCode.OK, null);
            var httpRule = new HttpRule(httpFilter, httpAction, 1);
            return httpRule;
        }
    }
}
