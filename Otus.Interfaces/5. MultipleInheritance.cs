using System;

namespace Otus.Interfaces
{
  public class Person : ICloneable, IComparable<Person>
  {
    private bool _somePrivateVariable;

    public Person(string name)
    {
      Name = name;
    }

    private Person()
    {
    }

    public string Name { get; private set; }

    public object Clone()
    {
      return new Person
      {
        Name = this.Name,
        _somePrivateVariable = this._somePrivateVariable
      };
    }

    public int CompareTo(Person other)
    {
      if (ReferenceEquals(this, other))
      {
        return 0;
      }

      if (ReferenceEquals(null, other))
      {
        return 1;
      }

      return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
  }
}