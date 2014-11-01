using System;

namespace Utils
{
    class Paths
    {
        public static readonly string CurrentUserProfilPathString = "/View/PMCurrentUserProfilView.xaml";
        public static readonly string ServerAddress = "162";

        public static readonly Uri LogInView = new Uri("/View/Logos/PMLogInView.xaml", UriKind.Relative);

        static Paths()
        {
            
        }
    }
}
