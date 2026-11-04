class Program
{
    private static void Main(string[] args)
    {
        //var service1 = new OrderService(new SMS("123-456-7890"));
        //service1.Notifies();
        //var service2 = new OrderService(new Email("customer@example.com"));
        //service2.Notifies();
        //var service3 = new OrderService(new Push("user123"));
        //service3.Notifies();

        //trying option A
        var notifications = new List<INotification>
        {
            new SMS("123-456-7890"),
            new Email("customer@example.com"),
            new Push("user123")
        };
        var service = new OrderService(notifications);
        service.Notifies();
    }
}

//interface
interface INotification
{
    public string Recipient { get; set; }
    public void Send();
}

class SMS : INotification
{
    public string Recipient { get; set; }
    public SMS(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[SMS] Sending to {Recipient}: ....");
    }
}

class Email : INotification
{
    public string Recipient { get; set; }
    public Email(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[Email] Sending to {Recipient}: ....");
    }
}

class Push : INotification
{
    public string Recipient { get; set; }
    public Push(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send()
    {
        Console.WriteLine($"[Push] Sending to {Recipient}: ....");
    }
}

class OrderService
{
    private List<INotification> notifications = new List<INotification>();
    public OrderService (List<INotification> notifications)
    {
        this.notifications = notifications;
    }

    public void Notifies()
    {
        Console.WriteLine("Your order #123 is on the way.");
        foreach (var notification in notifications)
        {
            notification.Send();
        }
    }
}

class MultiChannel : INotification
{
    public string Recipient { get; set; }
    private List<INotification> notifications = new List<INotification>();
    public MultiChannel(List<INotification> notifications)
    {
        this.notifications = notifications;
    }
    public void Send()
    {
        foreach (var notification in notifications)
        {
            notification.Send();
        }
    }
}