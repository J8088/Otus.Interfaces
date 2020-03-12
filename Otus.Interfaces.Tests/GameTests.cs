using System.Collections.Generic;
using Moq;
using Xunit;

namespace Otus.Interfaces.Tests
{
  public class GameTests
  {
    [Fact]
    public void Game_saves_state()
    {
      var mock = new Mock<ISerializer>();
      
      mock
        .Setup(foo => foo.Serialize(It.IsAny<List<IGameObject>>()))
        .Returns(string.Empty);

      var game = new Game(mock.Object);

      game.Save();

      mock.Verify(foo => foo.Serialize(It.IsAny<List<IGameObject>>()));
    }
  }
}