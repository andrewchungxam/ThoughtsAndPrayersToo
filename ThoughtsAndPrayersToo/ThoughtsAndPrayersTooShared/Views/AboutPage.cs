using System;
using System.Collections.Generic;
using ThoughtsAndPrayersTooShared.Resources;
using ThoughtsAndPrayersTooTemplate.ViewModels;
using Xamarin.Forms;

namespace ThoughtsAndPrayersTooShared.Views
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
			var _aboutViewModel = new AboutViewModel();
			this.BindingContext = _aboutViewModel;

            this.Title = _aboutViewModel.Title;

            //ROW SIZING
            Grid aboutGrid = new Grid();
            aboutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			aboutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            //ROW 1 CONTROLS
            StackLayout logoBackground = new StackLayout()
            {
                BackgroundColor = ColorDictionary.Accent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Children = 
                {
                    new StackLayout() 
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Children = 
                        {
                            new ContentView()
                            {
                                Padding = new Thickness(0,40,0,40),
                                VerticalOptions = LayoutOptions.FillAndExpand,
                                Content = new Image()
                                {
                                    Source = "xamarin_logo.png",
                                    VerticalOptions = LayoutOptions.Center,
                                    HeightRequest = 64
                                }
                            }

                        }

                    }

                }
			};

            FormattedString formattedString1 = new FormattedString();

            formattedString1.Spans.Add
            (
                new Span()
                {
                    Text = "AppName",
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 22
                }
            );
            formattedString1.Spans.Add
            (
                new Span()
                {
                    Text = " ",
                }
            );
            formattedString1.Spans.Add
            (
				new Span()
				{
					Text = "1.0",
					ForegroundColor = ColorDictionary.LightTextColor
				}
			);

			FormattedString formattedString2 = new FormattedString();

            formattedString2.Spans.Add
            (
                new Span()
                {
                    Text = "This app is written in C# and native APIs using the",
                }
            );

			formattedString2.Spans.Add
			(
				new Span()
				{
					Text = " ",
				}
			);

			formattedString2.Spans.Add
			(
				new Span()
				{
					Text = "Xamarin Platform",
					FontAttributes = FontAttributes.Bold,
				}
			);

			formattedString2.Spans.Add
            (
				new Span()
				{
					Text = ".",
				}
            );

			FormattedString formattedString3 = new FormattedString();

			formattedString3.Spans.Add
			(
				new Span()
				{
					Text = "It shares code with its"
				}
			);

			formattedString3.Spans.Add
			(
				new Span()
				{
					Text = " "
				}
			);

			formattedString3.Spans.Add
			(
				new Span()
				{
					Text = "iOS, Android, and Windows",
					FontAttributes = FontAttributes.Bold,
				}
			);

			formattedString3.Spans.Add
			(
				new Span()
				{
					Text = ".",
				}
			);

            formattedString3.Spans.Add
            (
                new Span()
                {
                    Text = "versions.",
                }
            );

            var button1 = new Button()
            {
                Margin = new Thickness(0, 10, 0, 0),
                Text = "Learn more",
                BackgroundColor = ColorDictionary.Primary,
                TextColor = Color.White,
            };
            button1.SetBinding(Button.CommandProperty, nameof(_aboutViewModel.OpenWebCommand));

			//ROW 2 CONTROLS
			ScrollView aboutScrollView = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(16, 40, 16, 40),
                    Spacing = 10,
                    Children =
                    {
                        new Label()
                        {
                            Font = Font.SystemFontOfSize(22),
                            FormattedText = formattedString1
                        },
                        new Label()
                        {
							FormattedText = formattedString2
						},
                        new Label ()
                        {
                            FormattedText = formattedString3
                        },
                        button1

                    }
                }
            };
            	 					  
            aboutGrid.Children.Add(logoBackground, 0, 0);
			aboutGrid.Children.Add(aboutScrollView, 0, 1);

			Content = aboutGrid;
		}
    }
}

