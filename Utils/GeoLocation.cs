﻿using System;
using Windows.Devices.Geolocation;
using Utils;

namespace PinMessaging.Other
{
    public class PMGeoLocation
    {
        public Geoposition GeopositionUser = null;

        readonly Geolocator _geolocatorUser = new Geolocator();
        bool _firstPositionChanged = false;
        private bool _firstUpdateLocationOver = false;

        public PMGeoLocation()
        {
            _geolocatorUser.DesiredAccuracyInMeters = 1;
            _geolocatorUser.MovementThreshold = 0;
            _geolocatorUser.ReportInterval = 1000;
            _geolocatorUser.PositionChanged += geolocator_PositionChanged;
            _geolocatorUser.StatusChanged += geolocator_StatusChanged;
        }

        private void geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            if (args == null)
            {
                Logs.Error.ShowError("geolocator_StatusChanged: args is null");
                return;
            }

            switch (args.Status)
            {
                case PositionStatus.Ready:
                    // Location data is available
                    Logs.Output.ShowOutput("Location is available.");
                    break;

                case PositionStatus.Initializing:
                    // This status indicates that a GPS is still acquiring a fix
                    Logs.Output.ShowOutput("A GPS device is still initializing.");
                    break;

                case PositionStatus.NoData:
                    // No location data is currently available
                    Logs.Output.ShowOutput("Data from location services is currently unavailable.");
                    break;

                case PositionStatus.Disabled:
                    // The app doesn't have permission to access location,
                    // either because location has been turned off.
                    Logs.Output.ShowOutput("Your location is currently turned off. " +
                         "Change your settings through the Settings charm " +
                         " to turn it back on.");
                    break;

                case PositionStatus.NotInitialized:
                    // This status indicates that the app has not yet requested
                    // location data by calling GetGeolocationAsync() or
                    // registering an event handler for the positionChanged event.
                    Logs.Output.ShowOutput("Location status is not initialized because " +
                        "the app has not requested location data.");
                    break;

                case PositionStatus.NotAvailable:
                    // Location is not available on this version of Windows
                    Logs.Output.ShowOutput("You do not have the required location services " +
                        "present on your system.");
                    break;

                default:
                    Logs.Output.ShowOutput("Unknown status");
                    break;
            }
        }

        private void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            //Logs.Output.ShowOutput("New pos dispo: latitude:" + args.Position.Coordinate.Latitude + " longitude:" + args.Position.Coordinate.Longitude);

            if (args == null || args.Position == null || args.Position.Coordinate == null)
            {
                Logs.Error.ShowError("geolocator_PositionChanged: args is null");
                return;
            }
        }

        public async void UpdateLocation()
        {
            GeopositionUser = await _geolocatorUser.GetGeopositionAsync();
        }
    }
}
