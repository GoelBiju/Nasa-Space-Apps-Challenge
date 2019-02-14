using Xamarin.Forms;

namespace MapOverlay
{
	public class App : Application
	{
		public static double ScreenHeight;
		public static double ScreenWidth;

		public App ()
		{
            //MainPage = new MapPage ();

            // Create some tabbed pages.
            var tabs = new TabbedPage();

            // Search bar and map to discover stations (heatmap).
            tabs.Children.Add(new MapPageCS { Title = "airQ Pollution Map" }); // Icon

            // Pollution outlook provides health information regarding the selected station.
            //tabs.Children.Add(new OutlookPage { Title = "Outlook" }); // Icon

            MainPage = tabs;
        }

		protected override void OnStart ()
		{
            // Handle when your app starts

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

