using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Otus.Interfaces
{
  public class LineReader : IEnumerable<string>, IDisposable
  {
    private readonly Stream _stream;

    public LineReader(Stream stream)
    {
      _stream = stream ?? throw new ArgumentNullException(nameof(stream));
    }

    public void Dispose()
    {
      _stream.Dispose();
    }

    public IEnumerator<string> GetEnumerator()
    {
      using var reader = new StreamReader(_stream, leaveOpen: true);

      var nextLine = reader.ReadLine();
      if (nextLine != null)
      {
        yield return nextLine;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}