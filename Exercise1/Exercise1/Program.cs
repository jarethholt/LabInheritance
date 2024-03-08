namespace Exercise1;

internal class Program
{
    static void Main()
    {
        string name = Console.ReadLine()!;
        int age = int.Parse(Console.ReadLine()!);

        try
        {
            Child child = new(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}