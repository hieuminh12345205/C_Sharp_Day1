Console.WriteLine("Hello World!");

int a = ReadInteger("nhap a: ");
int b = ReadInteger("nhap b: ");
int c = ReadInteger("nhap c: ");

Console.WriteLine($"a+b+c={a + b + c}");

static int ReadInteger(string message)
{
    while (true)
    {
        Console.Write(message);

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }

        Console.WriteLine("nhap sai, nhap lai");
    }
}
