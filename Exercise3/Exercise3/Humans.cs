namespace Exercise3;

public class Human
{
    private string _firstName = default!;
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException(
                    paramName: "FirstName",
                    message: "Expected upper case letter!");
            if (value.Length <= 3)
                throw new ArgumentException(
                    paramName: "FirstName",
                    message: "Expected length at least 4 symbols!");
            _firstName = value;
        }
    }

    private string _lastName = default!;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException(
                    paramName: "LastName",
                    message: "Expected upper case letter!");
            if (value.Length <= 2)
                throw new ArgumentException(
                    paramName: "LastName",
                    message: "Expected length at least 3 symbols!");
            _lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
}


public class Student : Human
{
    private string _facultNumber = default!;
    public string FacultyNumber
    {
        get => _facultNumber;
        set
        {
            if (!value.All(char.IsLetterOrDigit))
                throw new ArgumentException(
                    paramName: "FacultyNumber",
                    message: "Invalid faculty number!");
            if (value.Length < 5 || value.Length > 10)
                throw new ArgumentException(
                    paramName: "FacultyNumber",
                    message: "Invalid faculty number!");
            _facultNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
        => FacultyNumber = facultyNumber;
    
}
