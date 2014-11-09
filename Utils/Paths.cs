using System;

namespace Utils
{
    class Paths
    {
        public static readonly string CurrentUserProfilPathString = "/View/PMCurrentUserProfilView.xaml";
        public static readonly string ServerAddress = "http://54.171.198.181/api/";

        public static readonly Uri LogInView = new Uri("/View/Logos/PMLogInView.xaml", UriKind.Relative);

        static Paths()
        {
            
        }
    }
}
