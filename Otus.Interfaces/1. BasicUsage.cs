namespace Otus.Interfaces
{
  public interface IGameObject
  {
    public delegate void MoveHandler(int dx, int dy);

    int X { get; }
    int Y { get; }
    void Move(int dx, int dy);
    event MoveHandler Moved;
  }

  public class Human : IGameObject
  {
    public int X { get; private set; }
    public int Y { get; private set; }
    
    public void Move(int dx, int dy)
    {
      X += dx;
      Y += dy;

      OnMoved(dx, dy);
    }

    public event IGameObject.MoveHandler Moved;

    protected virtual void OnMoved(int dx, int dy)
    {
      Moved?.Invoke(dx, dy);
    }
  }
}