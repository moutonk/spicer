using System;
using Microsoft.Phone.Net.NetworkInformation;

namespace Utils
{
    static class Connectivity
    {
        static Connectivity()
        {
            DeviceNetworkInformation.NetworkAvailabilityChanged += ChangeDetected;
        }

        public static  void ShowConnectivity()
        {
            Logs.Output.ShowOutput("IsCellularDataEnabled ? " + ((DeviceNetworkInformation.IsCellularDataEnabled) ? "Yes" : "No"));
            Logs.Output.ShowOutput("IsNetworkAvailable ? " + ((DeviceNetworkInformation.IsNetworkAvailable) ? "Yes" : "No"));
            Logs.Output.ShowOutput("IsWiFiEnabled ? " + ((DeviceNetworkInformation.IsWiFiEnabled) ? "Yes" : "No"));
        }

        static void ChangeDetected(object sender, NetworkNotificationEventArgs e)
        {
            string change;

            switch (e.NotificationType)
            {
                case NetworkNotificationType.InterfaceConnected:
                    change = "Connected to ";
                    break;
                case NetworkNotificationType.InterfaceDisconnected:
                    change = "Disconnected from ";
                    break;
                case NetworkNotificationType.CharacteristicUpdate:
                    change = "Characteristics changed for ";
                    break;
                default:
                    change = "Unknown change with ";
                    break;
            }

            var changeInformation = String.Format(" {0} {1} {2} ({3})",
                        DateTime.Now, change, e.NetworkInterface.InterfaceName,
                        e.NetworkInterface.InterfaceType);

            Logs.Output.ShowOutput(change + changeInformation);
        }
    }
}
