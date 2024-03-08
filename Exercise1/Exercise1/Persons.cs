namespace Exercise1;

public class Person
{
    private string _name = default!;
    protected virtual string Name
    {
        get => _name;
        set
        {
            if (value.Length < 3)
                throw new ArgumentOutOfRangeException(
                    "Name",
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
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    "Age",
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


public class Child(string name, int age) : Person(name, age)
{
    protected override int Age
    {
        get => base.Age;
        set
        {
            if (value > 15)
                throw new ArgumentOutOfRangeException(
                    "Age",
                    "Child's age must be less than or equal to 15!");
            base.Age = value;
        }
    }
}