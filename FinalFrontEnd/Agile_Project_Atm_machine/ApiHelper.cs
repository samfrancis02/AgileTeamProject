using System;
using System.Net.Http;

public static class ApiHelper
{
    public static HttpClient ApiClient { get; private set; }

    public static void InitializeClient()
    {
        ApiClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5037/api/atmAPI/") // Replace with your actual API URL
        };

        // Optional: Add default request headers or other initial configurations here
    }
}
