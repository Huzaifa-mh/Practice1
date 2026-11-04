class Program
{
    private static void Main(string[] args)
    {
        SMS sms = new SMS();
        Email email = new Email();
        Push push = new Push();
        OrderService orderService = new OrderService("Customer1");

    }
}

//interface
interface Inotification
{
    public string recipient { get; set; }
    public string message { get; set; }
}

class SMS : Inotification
{
    public string recipient { get; set; }
    public string message { get; set; }

    public void PrintMessage()
    {
        Console.WriteLine("[SMS] Sending to 0300-xxxxxxxx: ....");
    }
}

class Email : Inotification
{
    public string recipient { get; set; }
    public string message { get; set; }

    public void PrintMessage()
    {
        Console.WriteLine("[Email] Sending to 0300-xxxxxxxx: ....");
    }
}

class Push : Inotification
{
    public string recipient { get; set; }
    public string message { get; set; }
    public void PrintMessage()
    {
        Console.WriteLine("[Push] Sending to 0300-xxxxxxxx: ....");
    }
}

class OrderService
{
    private string sender;
    public OrderService (string sender)
    {
        this.sender = sender;
    }

    public void Notifies()
    {
        Console.WriteLine("Your order #123 is on the way!");
    }
}