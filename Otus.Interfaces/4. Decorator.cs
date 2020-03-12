using System;

namespace Otus.Interfaces
{
  public class ApiClientWithLogging : IApiClient
  {
    private readonly IApiClient _actualImplementation;

    public ApiClientWithLogging(IApiClient apiClient)
    {
      _actualImplementation = apiClient;
    }

    public void SendRequest()
    {
      Console.WriteLine("Отправка запроса");

      try
      {
        _actualImplementation.SendRequest();
        Console.WriteLine("Запрос отправлен");
      }
      catch (Exception e)
      {
        Console.WriteLine($"Ошибка при отправке запроса: {e.Message}");
        throw;
      }
    }
  }
}