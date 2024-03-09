namespace Exercise2;

internal class Program
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine()!;
            string title = Console.ReadLine()!;
            decimal price = decimal.Parse(Console.ReadLine()!);

            Book book = new(author, title, price);
            GoldenEditionBook goldenEditionBook = new(author, title, price);

            Console.WriteLine(book);
            Console.WriteLine();
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
