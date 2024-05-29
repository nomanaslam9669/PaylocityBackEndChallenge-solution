using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;


namespace ApiTests;

public class IntegrationTest : IDisposable
{
    private HttpClient? _httpClient;

    protected HttpClient HttpClient
    {
        get
        {
            if (_httpClient == default)
            {
                _httpClient = new WebApplicationFactory<Program>().CreateClient();//new HttpClient
                _httpClient.BaseAddress = new Uri("https://localhost:8000");

                //{
                //    //task: update your port if necessary | Done
                //    BaseAddress = new Uri("https://localhost:8000")
                //};
                //_httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
            }

            return _httpClient;
        }
    }

    public void Dispose()
    {
        HttpClient.Dispose();
    }
}

