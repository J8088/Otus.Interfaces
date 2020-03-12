namespace Otus.Interfaces
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      ISerializer serializer = new OtusXmlSerializer();
      
      var game = new Game(serializer);

      IGameObject human = new Human();
      game.AddObject(human);
      
      game.Save();
      
      //========================================================
      IApiClientFactory apiClientFactory = new ApiClientFactory();

      IApiClient client1 = apiClientFactory.CreateClient("http://our.api.com");
      IApiClient client2 = apiClientFactory.CreateClient("ws://our.api.com");

      // добавляем логгирование
      client1 = new ApiClientWithLogging(client1);
      client2 = new ApiClientWithLogging(client2);
      
      // вызываем методы
      client1.SendRequest();
      client2.SendRequest();

      //=============


      IReadRepository<object> r = new ReadRepository<string>();
      IWriteRepository<string> w = new WriteRepository<object>();
    }
  }
}