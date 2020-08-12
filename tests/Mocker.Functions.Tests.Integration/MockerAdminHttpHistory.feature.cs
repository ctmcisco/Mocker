﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Mocker.Functions.Tests.Integration
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class MockerAdminHttpHistoryFeature : object, Xunit.IClassFixture<MockerAdminHttpHistoryFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "MockerAdminHttpHistory.feature"
#line hidden
        
        public MockerAdminHttpHistoryFeature(MockerAdminHttpHistoryFeature.FixtureData fixtureData, Mocker_Functions_Tests_Integration_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "MockerAdminHttpHistory", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
 testRunner.Given("There is no HTTP history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Saves and retrieves HTTP history by HTTP method")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history by HTTP method")]
        [Xunit.InlineDataAttribute("1", "DELETE", "", new string[0])]
        [Xunit.InlineDataAttribute("3", "GET", "", new string[0])]
        [Xunit.InlineDataAttribute("1", "PATCH", "4", new string[0])]
        [Xunit.InlineDataAttribute("1", "POST", "5", new string[0])]
        [Xunit.InlineDataAttribute("10", "PUT", "6", new string[0])]
        [Xunit.InlineDataAttribute("1", "HEAD", "7", new string[0])]
        [Xunit.InlineDataAttribute("1", "OPTIONS", "8", new string[0])]
        [Xunit.InlineDataAttribute("1", "TRACE", "", new string[0])]
        public virtual void SavesAndRetrievesHTTPHistoryByHTTPMethod(string count, string httpMethod, string body, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("count", count);
            argumentsOfScenario.Add("httpMethod", httpMethod);
            argumentsOfScenario.Add("body", body);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history by HTTP method", null, tagsOfScenario, argumentsOfScenario);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 7
 testRunner.Given(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method {2} times", body, httpMethod, count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When(string.Format("I query for those {0} requests by HTTP method", httpMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then(string.Format("the result should have {0} requests", count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Saves and retrieves HTTP history by HTTP method and body")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history by HTTP method and body")]
        [Xunit.InlineDataAttribute("1", "POST", "4", "6", new string[0])]
        [Xunit.InlineDataAttribute("2", "OPTIONS", "8", "9", new string[0])]
        public virtual void SavesAndRetrievesHTTPHistoryByHTTPMethodAndBody(string count, string httpMethod, string body1, string body2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("count", count);
            argumentsOfScenario.Add("httpMethod", httpMethod);
            argumentsOfScenario.Add("body1", body1);
            argumentsOfScenario.Add("body2", body2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history by HTTP method and body", null, tagsOfScenario, argumentsOfScenario);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 22
 testRunner.Given(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method {2} times", body1, httpMethod, count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.And(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method {2} times", body2, httpMethod, count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.When(string.Format("I query for those {0} requests by HTTP method and body {1}", httpMethod, body1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.Then(string.Format("the result should have {0} requests", count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Saves and retrieves HTTP history by HTTP method and JSON body")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history by HTTP method and JSON body")]
        [Xunit.InlineDataAttribute("1", "POST", "{\"name\": \"mark\"}", "{\"name\": \"markg\"}", new string[0])]
        [Xunit.InlineDataAttribute("2", "OPTIONS", "{\"name\": \"mark\",\"gender\": \"male\"}", "{\"name\": \"mark\",\"favouriteTeam\": \"Chelsea\"}", new string[0])]
        public virtual void SavesAndRetrievesHTTPHistoryByHTTPMethodAndJSONBody(string count, string httpMethod, string body1, string body2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("count", count);
            argumentsOfScenario.Add("httpMethod", httpMethod);
            argumentsOfScenario.Add("body1", body1);
            argumentsOfScenario.Add("body2", body2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history by HTTP method and JSON body", null, tagsOfScenario, argumentsOfScenario);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 32
 testRunner.Given(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method {2} times", body1, httpMethod, count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 33
 testRunner.And(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method {2} times", body2, httpMethod, count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.When(string.Format("I query for those {0} requests by HTTP method and body {1}", httpMethod, body1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
 testRunner.Then(string.Format("the result should have {0} requests", count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Saves and retrieves HTTP history by HTTP method and route")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history by HTTP method and route")]
        [Xunit.InlineDataAttribute("1", "POST", "api/4", "api/6", new string[0])]
        [Xunit.InlineDataAttribute("2", "OPTIONS", "api/8", "api/9", new string[0])]
        public virtual void SavesAndRetrievesHTTPHistoryByHTTPMethodAndRoute(string count, string httpMethod, string route1, string route2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("count", count);
            argumentsOfScenario.Add("httpMethod", httpMethod);
            argumentsOfScenario.Add("route1", route1);
            argumentsOfScenario.Add("route2", route2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history by HTTP method and route", null, tagsOfScenario, argumentsOfScenario);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 42
 testRunner.Given(string.Format("I have made a {0} HTTP request {1} times to route {2}", httpMethod, count, route1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
 testRunner.And(string.Format("I have made a {0} HTTP request {1} times to route {2}", httpMethod, count, route2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.When(string.Format("I query for those {0} requests by HTTP method and route {1}", httpMethod, route1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 45
 testRunner.Then(string.Format("the result should have {0} requests", count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Saves and retrieves HTTP history by HTTP method and correct timestamp returned")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history by HTTP method and correct timestamp returned")]
        [Xunit.InlineDataAttribute("GET", "", new string[0])]
        [Xunit.InlineDataAttribute("POST", "5", new string[0])]
        public virtual void SavesAndRetrievesHTTPHistoryByHTTPMethodAndCorrectTimestampReturned(string httpMethod, string body, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("httpMethod", httpMethod);
            argumentsOfScenario.Add("body", body);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history by HTTP method and correct timestamp returned", null, tagsOfScenario, argumentsOfScenario);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 52
 testRunner.Given(string.Format("I have sent {0} to the HTTP mock using the {1} HTTP method 1 times", body, httpMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 53
 testRunner.When(string.Format("I query for those {0} requests by HTTP method", httpMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
 testRunner.Then("the result should correct timestamp data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Saves and retrieves HTTP history (large request) by HTTP method")]
        [Xunit.TraitAttribute("FeatureTitle", "MockerAdminHttpHistory")]
        [Xunit.TraitAttribute("Description", "Saves and retrieves HTTP history (large request) by HTTP method")]
        public virtual void SavesAndRetrievesHTTPHistoryLargeRequestByHTTPMethod()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Saves and retrieves HTTP history (large request) by HTTP method", null, tagsOfScenario, argumentsOfScenario);
#line 60
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 61
 testRunner.Given("I have sent a large request body to the HTTP mock using the POST HTTP method 2 ti" +
                        "mes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 62
 testRunner.When("I query for those POST requests by HTTP method", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then("the result should have 2 requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.And("the large request body should be correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                MockerAdminHttpHistoryFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                MockerAdminHttpHistoryFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
