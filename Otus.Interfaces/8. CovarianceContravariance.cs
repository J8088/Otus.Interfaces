using System;
using System.Collections.Generic;

namespace Otus.Interfaces
{
  /// <summary>
  ///   Ковариантный интерфейс
  /// </summary>
  public interface IReadRepository<out T>
  {
    IEnumerable<T> GetAll();
  }

  /// <summary>
  ///   Контравариантный интерфейс
  /// </summary>
  public interface IWriteRepository<in T>
  {
    void Add(T item);
  }

  internal class WriteRepository<T> : IWriteRepository<T>
  {
    public void Add(T item)
    {
      throw new NotImplementedException();
    }
  }

  internal class ReadRepository<T> : IReadRepository<T>
  {
    public IEnumerable<T> GetAll()
    {
      throw new NotImplementedException();
    }
  }

  internal class CovarianceContravariance
  {
    private static void Run()
    {
      // Ссылка общего типа, содержит указатель на более конкретный тип  
      IReadRepository<object> r = new ReadRepository<string>();

      IEnumerable<object> objects = r.GetAll();

      // Ссылка конкретного типа, содержит указатель на более общий тип  
      IWriteRepository<string> w = new WriteRepository<object>();
      w.Add("Item");
    }
  }
}