using System.Text;

namespace Exercise2;

public class Book
{
    private string _author = default!;
    protected string Author
    {
        get => _author;
        set
        {
            // Check whether 1st character of 2nd name is a digit
            if (char.IsDigit(value.Split()[1], 0))
                throw new ArgumentException(
                    paramName: "Author",
                    message: "Author not valid!");
            _author = value;
        }
    }

    private string _title = default!;
    protected string Title
    {
        get => _title;
        set
        {
            if (value.Length < 3)
                throw new ArgumentException(
                    paramName: "Title",
                    message: "Title not valid!");
            _title = value;
        }
    }
    
    private decimal _price;
    protected virtual decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    paramName:
                    "Price", message: "Price not valid!");
            _price = value;
        }
    }
    
    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Type: {this.GetType().Name}")
          .AppendLine($"Title: {Title}")
          .AppendLine($"Author: {Author}")
          .AppendLine($"Price: {Price:C2}");
        return sb.ToString().TrimEnd();
    }
    
}