namespace Tawsela.Patterns
{
    // Singleton pattern
    public sealed class NotificationManager
    {
        private static NotificationManager _instance = new NotificationManager();
        private NotificationManager() { }

        public static NotificationManager Instance => _instance;

        public void Notify(string message)
        {
            Console.WriteLine($"[Notification] {message}");
        }
    }
}