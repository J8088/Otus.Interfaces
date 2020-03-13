using System.Xml;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;

namespace Otus.Interfaces
{
  public interface ISerializer
  {
    string Serialize<T>(T item);
  }

  public class OtusXmlSerializer : ISerializer
  {
    private static readonly XmlWriterSettings XmlWriterSettings;

    static OtusXmlSerializer()
    {
      XmlWriterSettings = new XmlWriterSettings {Indent = true};
    }

    public string Serialize<T>(T item)
    {
      // using a 3rd party serializer 'cause the default one cannot serialize interfaces
      // https://github.com/ExtendedXmlSerializer/home
      IExtendedXmlSerializer serializer = new ConfigurationContainer()
        .UseAutoFormatting()
        .UseOptimizedNamespaces()
        .EnableImplicitTyping(typeof(T))
        .Create();

      return serializer.Serialize(XmlWriterSettings, item);
    }
  }
}