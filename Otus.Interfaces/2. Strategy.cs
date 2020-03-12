using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Otus.Interfaces
{
  public interface ISerializer
  {
    string Serialize<T>(T item);
  }

  public class OtusXmlSerializer : ISerializer
  {
    public string Serialize<T>(T item)
    {
      using var sw = new StringWriter();
      using var xw = XmlWriter.Create(sw);

      var serializer = new XmlSerializer(typeof(T));
      serializer.Serialize(xw, item);

      return sw.ToString();
    }
  }
}