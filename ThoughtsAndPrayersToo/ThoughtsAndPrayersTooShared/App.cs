using System;
using ThoughtsAndPrayersTooShared.Resources;
using ThoughtsAndPrayersTooShared.Views;
using ThoughtsAndPrayersTooTemplate.Services;
using Xamarin.Forms;

namespace ThoughtsAndPrayersTooTemplate
{
	public class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string BackendUrl = "https://localhost:5000";

		public App()
		{
            //DATA SOURCES
			if (UseMockDataStore)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<CloudDataStore>();

			if (Device.RuntimePlatform == Device.iOS)
				MainPage = new MainPage();
			else
				MainPage = new NavigationPage(new MainPage());

			//ADDING STYLES TO RESOURCE DICTIONARIES
			Resources = new ResourceDictionary();
			//IMPLICIT 
			Resources.Add(StyleDictionary.navigationPageStyle);
			//EXPLICIT
			//Resources.Add("navigationPageStyle", StyleDictionary.navigationPageStyle );

		}
	}
}
