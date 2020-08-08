# Mocker

An API to mock responses from HTTP APIs to help with testing.

Simply create a rule which defines the response you want based on the request body, header, query and method in a received request. The response can be configured with custom headers, body, HTTP Status Code and delay.

## Contents

* [Getting started](#getting-started)
  * [Simple example using PowerShell](#simple-example-using-powershell)
  * [Complex example using PowerShell](#complex-example-using-powershell)
  * [Complex example using C#](#complex-example-using-c#)
* [HTTP Rule Management](#http-rule-management)
  * [Add a rule](#add-a-rule)
  * [Delete all rules](#delete-all-rules)
  * [Get all rules](#get-all-rules)
* [Understanding the HTTP Rule Engine](#understanding-the-http-rule-engine)
  * [Rule processing order](#rule-processing-order)
  * [Working with large rule bodies](#working-with-large-rule-bodies)

## Getting started

### Simple example using PowerShell

1) Deploy Mocker to an Azure Function or container on Kubernetes or Docker or run it locally using Azure Functions tools. Example below has Mocker running locally on [http://localhost:7071](http://localhost:7071).

2) Create a rule: If request body is `Hello world!` then respond back with a body of `Hello back!`.

    ```PowerShell
    $rule = '{
                "filter": {
                    "body": "Hello world!"
                },
                "action": {
                    "body": "Hello back!"
                }
            }'

    Invoke-WebRequest -Uri http://localhost:7071/mockeradmin/http/rules -Method Post -Body $rule

    # Returns 200, OK response
    ```

3) Send a request to Mocker with body `Hello world!` and receive a response of `Hello back!`.

    ```PowerShell
    Invoke-WebRequest -Uri http://localhost:7071 -Method Post -Body "Hello world!"

    # Returns Hello back!
    ```

### Complex example using PowerShell

1) Deploy Mocker to an Azure Function or container on Kubernetes or Docker or run it locally using Azure Functions tools. Example below has Mocker running locally on [http://localhost:7071](http://localhost:7071).

2) Create a rule based on body, headers, method, query and route. This responds back with a 202 status code after approx 500ms with success header.

    ```PowerShell
    $rule = '{
                "filter": {
                    "body": "{\"Name\": \"Mark\"}",
                    "headers": {
                        "AuthKey": [
                            "Password1"
                        ]
                    },
                    "method": "POST",
                    "query": {
                        "objecttype": "contact"
                    },
                    "route": "addobject"
                },
                "action": {
                    "body": "{\"ObjectId\": \"12345\"}",
                    "delay": 500,
                    "statusCode": 202,
                    "headers": {
                        "Result": [
                            "success"
                        ]
                    }
                }
            }'

    Invoke-WebRequest -Uri http://localhost:7071/mockeradmin/http/rules -Method Post -Body $rule

    # Returns 200, OK response
    ```

3) Submit a matching request to Mocker

    ```PowerShell
    $headers = @{AuthKey = "Password1"}
    $body = '{"Name": "Mark"}'

    Invoke-WebRequest -Uri http://localhost:7071/addobject?objecttype=contact -Method Post -Body $body -Headers $headers

    # Returns 202, Accepted
    # Body: {"ObjectId": "12345"}
    # Headers include: Result = success
    ```

4) Check that the correct request was sent

    ```PowerShell
    Invoke-WebRequest -Uri "http://localhost:7071/mockeradmin/http/history?method=post&route=addobject"

    # Returns matching request details
    #[
    #     {
    #         "Body": "{\"Name\": \"Mark\"}",
    #         "Headers": {
    #             "Content-Type": [
    #                 "application/x-www-form-urlencoded"
    #             ],
    #             "Host": [
    #                 "localhost:7071"
    #             ],
    #             "User-Agent": [
    #                 "Mozilla/5.0 (Windows NT 10.0; Microsoft Windows 10.0.18363; en-GB) PowerShell/7.0.2"
    #             ],
    #             "Content-Length": [
    #                 "16"
    #             ],
    #             "AuthKey": [
    #                 "Password1"
    #             ]
    #         },
    #         "Method": "POST",
    #         "Query": {
    #             "objecttype": "contact"
    #         },
    #         "Route": "addobject",
    #         "Timestamp": "2020-08-05T22:48:16.7174817Z"
    #     }
    # ]
    ```

### Complex example using C#

The example below shows an integration test for a WeatherService which calls an API to get the temperature for a given location.

The test performs the below tasks:

1. Clears all rules from Mocker
2. Clears all request history from Mocker
3. Adds a new rule to Mocker that responds to a `WeatherServiceTemperatureRequest` which has specific headers, method, query and route with a custom `WeatherServiceTemperatureResponse`, with a HTTP status code of 200 and custom headers after a delay of approx. 500ms.
4. Calls the `WeatherService.GetTemperature()` method (system under test)
5. Asserts the output from the `WeatherService`
6. Calls the Mocker Http History API to assert that the correct request was received and only one request was received.

See the full example project in the `examples` folder.

```C#
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Tests
{
    public class MockerExample
    {
        private const string _mockerAdminBaseUrl = "http://localhost:7071";

        [Theory]
        [InlineData("Paris", "10")]
        [InlineData("Kuala Lumpur", "31")]
        public async Task TestCorrectWeatherServiceTemperature(string location, string temperature)
        {
            using var httpClient = new HttpClient();

            var expectedTemperature = int.Parse(temperature);

            // ARRANGE
            // Clear all rules from mocker
            await httpClient.DeleteAsync($"{_mockerAdminBaseUrl}/mockeradmin/http/rules");

            // Clear all request history from mocker
            await httpClient.DeleteAsync($"{_mockerAdminBaseUrl}/mockeradmin/http/history");

            // Add new mocker rule which returns the correct temperature based on location
            var expectedBody = JsonSerializer.Serialize(new WeatherServiceTemperatureRequest(location));
            var expectedRoute = "getLocalWeather";
            var newMockerRule = new HttpRuleRequest
            {
                Filter = new HttpRuleFilterRequest
                {
                    Body = expectedBody,
                    Headers = new Dictionary<string, List<string>> { { "code", new List<string> { "12345" } } },
                    Method = "POST",
                    Query = new Dictionary<string, string> { { "temperatureOnly", "true" } },
                    Route = expectedRoute
                },
                Action = new HttpRuleActionRequest
                {
                    Body = JsonSerializer.Serialize(new WeatherServiceTemperatureResponse { Temperature = expectedTemperature }),
                    Delay = 500,
                    Headers = new Dictionary<string, List<string>> { { "result", new List<string> { "success" } } },
                    StatusCode = HttpStatusCode.OK
                }
            };

            var jsonRequest = JsonSerializer.Serialize(newMockerRule);
            using var httpContent = new StringContent(jsonRequest);
            await httpClient.PostAsync($"{_mockerAdminBaseUrl}/mockeradmin/http/rules", httpContent);

            // ACT
            var sut = new WeatherService();
            var actual = await sut.GetTemperature(location);

            // ASSERT
            // Assert correct response from SUT
            Assert.Equal(expectedTemperature, actual);

            // Assert correct request was sent to the Weather API
            var response = await httpClient.GetAsync($"{_mockerAdminBaseUrl}/mockeradmin/http/history?method=POST");
            var json = await response.Content.ReadAsStringAsync();
            var requests = JsonSerializer.Deserialize<List<HttpHistoryItem>>(json);
            Assert.Single(requests);
            Assert.Equal(expectedBody, requests[0].Body);
            Assert.Equal(expectedRoute, requests[0].Route);
        }
    }

    public class WeatherService
    {
        private readonly string _weatherServiceUrl = "http://localhost:7071/getLocalWeather?temperatureOnly=true";

        public async Task<int> GetTemperature(string location)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("code", "12345");

            var jsonRequest = JsonSerializer.Serialize(new WeatherServiceTemperatureRequest(location));
            using var httpContent = new StringContent(jsonRequest);
            var response = await httpClient.PostAsync(_weatherServiceUrl, httpContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherServiceTemperatureResponse>(jsonResponse);

            return weatherData.Temperature;
        }
    }

    public class WeatherServiceTemperatureRequest
    {
        public string Location { get; }

        public WeatherServiceTemperatureRequest(string location)
        {
            Location = location;
        }
    }

    public class WeatherServiceTemperatureResponse
    {
        public int Temperature { get; set; }
    }

    public class HttpRuleRequest
    {
        public HttpRuleFilterRequest Filter { get; set; }

        public HttpRuleActionRequest Action { get; set; }
    }

    public class HttpRuleFilterRequest
    {
        public string Body { get; set; }
        public Dictionary<string, List<string>> Headers { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Query { get; set; }
        public string Route { get; set; }
    }

    public class HttpRuleActionRequest
    {
        public string Body { get; set; }
        public int Delay { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Dictionary<string, List<string>> Headers { get; set; }
    }

    public class HttpHistoryItem
    {
        public string Body { get; set; }
        public Dictionary<string, List<string>> Headers { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Query { get; set; }
        public string Route { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
```

## HTTP Rule Management

Mocker has an Rule Admin API `http://<MyMockerUrl>/mockeradmin/http/rule` which can be used manage rules. Rules are stored in table storage with some large rules storing data in blob storage in the same storage account.

### Add a rule

To add a rule, POST to the `http://<MyMockerUrl>/mockeradmin/http/rule` and pass JSON as below.

#### Filter

Defines which HTTP requests the rule will apply to based on various HTTP request properties. All filter properties are optional but the filter block is not. If an empty filter block is specified then the rule will apply to all requests. In addition, if any properties below are not specified then all property values will be matched.

| Property | Required? | Description |
|-|-|-|
| Body | No | The request body which the rule will apply to. This is an exact string match. |
| Headers | No | A dictionary of string and list of string which denotes the headers of the request that the rule will apply to. The rule will apply to any received request that contains the filter headers. |
| Method | No | The request method which the rule will apply to |
| Query | No | The query string parameters which the rule will apply to. This is passed as a dictionary of string and string. The rule will apply to any received request that contains the filter query parameters. |
| Route | No | The API route that the rule will apply to e.g. customer/address/update |

### Action

Defines the action the rule will take in response to a matching request. At least one of the properties below must be specified.

| Property | Required? | Description |
|-|-|-|
| Body | No | The body of the response. Default is an empty string. |
| Delay | No | The response delay in milliseconds. Default is 0. |
| Headers | No | A dictionary of string and list of string which denotes the response headers. Default is an empty header. |
| StatusCode | No | The numeric status code returned in the response e.g. 202. The default is 200 OK. |

Example simple rule:

```Json
{
    "filter": {
        "method": "POST"
    },
    "action": {
        "body": "Your request was accepted",
        "statusCode": 202
    }
}
```

Example complex rule:

```Json
{
    "filter": {
        "body": "{\"Name\": \"Mark\"}",
        "headers": {
            "AuthKey": [
                "Password1"
            ]
        },
        "method": "POST",
        "query": {
            "objecttype": "contact"
        },
        "route": "addobject"
    },
    "action": {
        "body": "{\"ObjectId\": \"12345\"}",
        "delay": 500,
        "statusCode": 202,
        "headers": {
            "Result": [
                "success"
            ]
        }
    }
}
```

#### C# Rule Request Classes

The below C# classes can be used to generate the JSON requests of the correct schema above. Also see the [C# example](#complex-example-using-c#) above.

```C#
public class HttpRuleRequest
{
    public HttpRuleFilterRequest Filter { get; set; }

    public HttpRuleActionRequest Action { get; set; }
}

public class HttpRuleFilterRequest
{
    public string Body { get; set; }
    public Dictionary<string, List<string>> Headers { get; set; }
    public string Method { get; set; }
    public Dictionary<string, string> Query { get; set; }
    public string Route { get; set; }
}

public class HttpRuleActionRequest
{
    public string Body { get; set; }
    public int Delay { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public Dictionary<string, List<string>> Headers { get; set; }
}
```

### Delete all rules

To delete all rules, send an HTTP DELETE request to `http://<MyMockerUrl>/mockeradmin/http/rule`.

### Get all rules

To get all rules, send an HTTP GET request to `http://<MyMockerUrl>/mockeradmin/http/rule`.

## Understanding the HTTP Rule Engine

### Rule processing order

Rules are evaluated in the order they are added to Mocker. For this reason, the most specific rules should be added first and the least specific should be last.

### Working with large rule bodies

Any large filter and action bodies of over 30000 characters will be stored in blob storage in the same storage account.

For large body filters, these will not be evaluated if they are over 30000 characters long. If this is the case, use one of the other filters. Large action bodies will be processed as normal.
