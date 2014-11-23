using System;

namespace Utils
{
    public class Paths
    {
        public static readonly Uri ConnectionView = new Uri("/View/LoginView.xaml", UriKind.Relative);
        public static readonly Uri SignUpView = new Uri("/View/SignUpView.xaml", UriKind.Relative);

        public static readonly string ServerAddress = "http://54.171.198.181/api/";

        static Paths()
        {
            
        }
    }
}
