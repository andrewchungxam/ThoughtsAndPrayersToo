using System;
using Xamarin.Forms;

namespace ThoughtsAndPrayersTooShared.Resources
{
    public static class ColorDictionary
    {
        public static readonly Color Primary = Color.FromHex("#2196F3");
        public static readonly Color PrimaryDark = Color.FromHex("#1976D2");
        public static readonly Color Accent = Color.FromHex("#96d1ff");
        public static readonly Color LightBackgroundColor = Color.FromHex("#FAFAFA");
        public static readonly Color DarkBackgroundColor = Color.FromHex("#C0C0C0");
        public static readonly Color MediumGrayTextColor = Color.FromHex("#4d4d4d");
        public static readonly Color LightTextColor = Color.FromHex("#999999");
    }

    public static class StyleDictionary
    {
        //TO APPLY BELOW STYLES IN APPLICATION - ADD TO A RESOURCE DICTIONARY IN THE APP CLASS
        public static Style navigationPageStyle = new Style(typeof(NavigationPage))
        {
            Setters = {
                new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = ColorDictionary.Primary },
                new Setter { Property = NavigationPage.BarTextColorProperty, Value = "White"}
            }
        };

		public static Style buttonStyle = new Style(typeof(Button))
		{
			Setters = {
				new Setter { Property = Button.TextColorProperty,   Value = Color.Teal }
			}
		};
	}
}