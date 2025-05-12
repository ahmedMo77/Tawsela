using Tawsela.Patterns;

public class NotificationService : INotificationService
{
    public void Notify(string message)
    {
        NotificationManager.Instance.Notify(message);
    }
}
