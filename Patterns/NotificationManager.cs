namespace Tawsela.Patterns
{
    // Singleton pattern
    public class NotificationManager
    {
        private static NotificationManager _instance = null;
        private NotificationManager() 
        {
            if (_instance == null)
                _instance = new NotificationManager();
        }

        public static NotificationManager Instance => _instance;

        public void Notify(string message)
        {
            Console.WriteLine($"[Notification] {message}");
        }
    }
}