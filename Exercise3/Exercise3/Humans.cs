using System.Text;

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

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        return sb.ToString();
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
    
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(base.ToString());
        sb.AppendLine($"Faculty number: {FacultyNumber}");
        return sb.ToString();
    }
    
}


public class Worker : Human
{
    private decimal _weekSalary;
    public decimal WeekSalary
    {
        get => _weekSalary;
        set
        {
            if (value <= 10m)
                throw new ArgumentOutOfRangeException(
                    paramName: "WeekSalary",
                    message: "Expected value mismatch!");
            _weekSalary = value;
        }
    }

    private int _hoursPerDay;
    public int HoursPerDay
    {
        get => _hoursPerDay;
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentOutOfRangeException(
                    paramName: "HoursPerDay",
                    message: "Expected value mismatch!");
            _hoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        HoursPerDay = workHoursPerDay;
    }

    public decimal HourSalary
    {
        get => WeekSalary / (HoursPerDay * 5);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(base.ToString());
        sb.AppendLine($"Week Salary: {WeekSalary:C2}");
        sb.AppendLine($"Hours per day: {(decimal)HoursPerDay:C2}");
        sb.AppendLine($"Salary per hour: {HourSalary:C2}");
        return sb.ToString();
    }

}
