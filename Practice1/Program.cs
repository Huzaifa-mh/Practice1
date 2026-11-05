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
        var service = new OrderService(new MultiChannel(notifications));
        service.Notifies();
    }
}

//interface
interface INotification
{
    public void Send(string message);
}

class SMS : INotification
{
    public string Recipient { get; set; }
    public SMS(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] Sending to {Recipient}: {message}");
    }
}

class Email : INotification
{
    public string Recipient { get; set; }
    public Email(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send(string message)
    {
        Console.WriteLine($"[Email] Sending to {Recipient}: {message}");
    }
}

class Push : INotification
{
    public string Recipient { get; set; }
    public Push(string Recipient)
    {
        this.Recipient = Recipient;
    }
    public void Send(string message)
    {
        Console.WriteLine($"[Push] Sending to {Recipient}: {message}");
    }
}

class OrderService
{
    private INotification notification;
    public OrderService (INotification notifications)
    {
        this.notification = notifications;
    }

    public void Notifies()
    {
        notification.Send("Your order #123 is on the way.");
    }
}

class MultiChannel : INotification
{
    private List<INotification> notifications = new List<INotification>();
    public MultiChannel(List<INotification> notifications)
    {
        this.notifications = notifications;
    }
    public void Send(string message)
    {
        foreach (var notification in notifications)
        {
            notification.Send(message);
        }
    }
}