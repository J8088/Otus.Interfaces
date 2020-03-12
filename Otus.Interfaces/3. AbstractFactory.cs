using System;

namespace Otus.Interfaces
{
  public interface IApiClient
  {
    void SendRequest();
  }

  public interface IApiClientFactory
  {
    IApiClient CreateClient(string url);
  }

  public class ApiClientFactory : IApiClientFactory
  {
    public IApiClient CreateClient(string url)
    {
      if (url.StartsWith("ws://"))
      {
        return new WebSocketApiClient();
      }

      return new HttpApiClient();
    }
  }

  internal class HttpApiClient : IApiClient
  {
    public void SendRequest()
    {
      Console.WriteLine("http запрос");
    }
  }

  internal class WebSocketApiClient : IApiClient
  {
    public void SendRequest()
    {
      Console.WriteLine("веб-сокет запрос");
    }
  }
}