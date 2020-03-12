using System;

namespace Otus.Interfaces
{
  public interface ILogger
  {
    void Log(string message);

    void LogError(Exception exception, string message)
    {
      Log(
        $"{message}" +
        $"{Environment.NewLine}Exception: {exception.Message}" +
        $"{Environment.NewLine}Stack trace: {exception.StackTrace}"
      );
    }
  }

  class Logger : ILogger
  {
    public void Log(string message)
    {
      Console.WriteLine(message);
    }
  }
}