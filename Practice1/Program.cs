class Program
{
    private static void Main(string[] args)
    {
        var service1 = new OrderService(new SMS("123-456-7890"));
        service1.Notifies();
        var service2 = new OrderService(new Email("customer@example.com"));
        service2.Notifies();
        var service3 = new OrderService(new Push("user123"));
        service3.Notifies();

    }
}

//interface
interface INotification
{
    public string recipient { get; set; }
    public void Send();
}

class SMS : INotification
{
    public string recipient { get; set; }
    public SMS(string recipient)
    {
        this.recipient = recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[SMS] Sending to {recipient}: ....");
    }
}

class Email : INotification
{
    public string recipient { get; set; }
    public Email(string recipient)
    {
        this.recipient = recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[Email] Sending to {recipient}: ....");
    }
}

class Push : INotification
{
    public string recipient { get; set; }
    public Push(string recipient)
    {
        this.recipient = recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[Push] Sending to {recipient}: ....");
    }
}

class OrderService
{
    private INotification notification;
    public OrderService (INotification notification)
    {
        this.notification = notification;
    }

    public void Notifies()
    {
        notification.Send();
    }
}