using System;

namespace Utils
{
    class Paths
    {
        public static readonly string CurrentUserProfilPathString = "/View/PMCurrentUserProfilView.xaml";
        public static readonly string ServerAddress = "http://163.5.84.244/Spring/";

        public static readonly Uri LogInView = new Uri("/View/Logos/PMLogInView.xaml", UriKind.Relative);

        static Paths()
        {
            
        }
    }
}
