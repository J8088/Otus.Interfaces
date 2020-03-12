namespace Otus.Interfaces
{
  public interface IBaseInterface
  {
    void Action();
  }

  public interface IDerivedInterface : IBaseInterface
  {
    void Move();
    new void Action();
  }

  public class MyClass : IDerivedInterface
  {
    public void Move()
    {
      throw new System.NotImplementedException();
    }

    void IDerivedInterface.Action()
    {
      throw new System.NotImplementedException();
    }

    void IBaseInterface.Action()
    {
      throw new System.NotImplementedException();
    }
  }
}