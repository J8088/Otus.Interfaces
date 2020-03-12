using System;
using System.Collections.Generic;
using System.IO;

namespace Otus.Interfaces
{
  public class Game
  {
    private readonly List<IGameObject> _gameObjects;
    private readonly ISerializer _serializer;

    public Game(ISerializer serializer)
    {
      _serializer = serializer;
      _gameObjects = new List<IGameObject>();
    }

    public void AddObject(IGameObject gameObject)
    {
      if (gameObject == null)
      {
        throw new ArgumentNullException(nameof(gameObject));
      }

      _gameObjects.Add(gameObject);
    }

    public void Save()
    {
      var state = _serializer.Serialize(_gameObjects);
      File.WriteAllText("./game.state", state);
    }
  }
}