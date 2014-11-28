using System;
using Microsoft.Phone.Notification;

namespace Utils
{
    public static class NotificationCenter
    {
        public enum NotificationType
        {
        }

        /// Holds the push channel that is created or found.
        private static readonly HttpNotificationChannel PushChannel;

        public static string PushChannelUri { get; set; }
        private static readonly string ChannelName = "ToastChannel" + All.GetPhoneUniqueId();

        //call static constructor
        public static void Start() {}

        static NotificationCenter()
        {
            Logs.Output.ShowOutput("NotificationCenter constructor begin");

            // Try to find the push channel.
            PushChannel = HttpNotificationChannel.Find(ChannelName);

            // If the channel was not found, then create a new connection to the push service.
            if (PushChannel == null)
            {
                PushChannel = new HttpNotificationChannel(ChannelName);
                
                // Register for all the events before attempting to open the channel.
                PushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
                PushChannel.ErrorOccurred += PushChannel_ErrorOccurred;

                // Register for this notification only if you need to receive the notifications while your application is running.
                //PushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(PushChannel_ShellToastNotificationReceived);
                PushChannel.ShellToastNotificationReceived += PushChannel_ShellToastNotificationReceived;

                PushChannel.Open();

                // Bind this new channel for toast events.
                PushChannel.BindToShellToast();
                //PushChannel.BindToShellTile();
            }
            else
            {
                // The channel was already open, so just register for all the events.
                PushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
                PushChannel.ErrorOccurred += PushChannel_ErrorOccurred;

                // Register for this notification only if you need to receive the notifications while your application is running.
                PushChannel.ShellToastNotificationReceived += PushChannel_ShellToastNotificationReceived;
          
                PushChannelUri = PushChannel.ChannelUri.ToString();
             
                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                Logs.Output.ShowOutput(String.Format("Channel Uri is {0}", PushChannel.ChannelUri));
            }
            Logs.Output.ShowOutput("NotificationCenter constructor end");
        }

        static void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            try
            {
                PushChannelUri = PushChannel.ChannelUri.ToString();
            }
            catch (Exception exp)
            {
                Logs.Output.ShowOutput(exp.Message + " " + exp.InnerException);
            }
       
            Logs.Output.ShowOutput("ChannelUri: " + e.ChannelUri);
            Logs.Output.ShowOutput("PushChannelUri: " + PushChannelUri);
        }

        static void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            Logs.Output.ShowOutput(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}", e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData));
        }

        static void PushChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            Logs.Output.ShowOutput("Notification received: " + DateTime.Now.TimeOfDay);
        }
    }
}
