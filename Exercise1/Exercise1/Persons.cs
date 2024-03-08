namespace Exercise1;

public class Person
{
    private string _name;
    protected virtual string Name
    {
        get => _name;
        set
        {
            if (value.Length < 3)
                throw new ArgumentException(
                    "Name's length should not be less than 3 symbols!");
            _name = value;
        }
    }

    private int _age;
    protected virtual int Age
    {
        get => _age;
        set
        {
            if (_age < 0)
                throw new ArgumentOutOfRangeException(
                    "Age must be positive!");
            _age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
    
}