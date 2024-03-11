namespace Exercise3;

internal class Program
{
    static void Main()
    {
        // Read first line: student data
        string[] studentData = Console.ReadLine()!.Split();
        try
        {
            Student student = new(studentData[0], studentData[1], studentData[2]);
            Console.Write(student.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();

        // Read second line: worker data
        string[] workerData = Console.ReadLine()!.Split();
        try
        {
            if (!decimal.TryParse(workerData[2], out decimal weekSalary))
                throw new ArgumentException(
                    paramName: "WeekSalary",
                    message: $"Could not parse '{workerData[2]}' as a decimal");
            if (!int.TryParse(workerData[3], out int hoursPerDay))
                throw new ArgumentException(
                    paramName: "HoursPerDay",
                    message: $"Could not parse '{workerData[3]}' as an integer");
            Worker worker = new(workerData[0], workerData[1], weekSalary, hoursPerDay);
            Console.Write(worker.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}