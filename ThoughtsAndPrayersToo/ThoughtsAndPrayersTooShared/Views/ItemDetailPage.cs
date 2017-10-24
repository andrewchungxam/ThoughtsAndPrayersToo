using System;
using System.Diagnostics;
using ThoughtsAndPrayersTooTemplate.Models;
using ThoughtsAndPrayersTooTemplate.ViewModels;
using Xamarin.Forms;

namespace ThoughtsAndPrayersTooShared.Views
{
    public class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel _viewModel;

		// Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
		public ItemDetailPage()
		{

			var item = new Item
			{
				Text = "Item 1",
				Description = "This is an item description."
			};

			_viewModel = new ItemDetailViewModel(item);
			BindingContext = _viewModel;
		}

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            BindingContext = this._viewModel = viewModel;
			this.SetBinding(TitleProperty, "Title");

			Label itemText = new Label() 
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
			itemText.SetBinding(Label.TextProperty, "Title");

			Label itemDescription = new Label()
			{
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};
			itemDescription.BindingContext = _viewModel.Item;
			itemDescription.SetBinding(Label.TextProperty, "Description");

			Content = new StackLayout()
            {
                Padding = new Thickness(15),
                Spacing = 20,
                Children = 
                {
                    itemText, itemDescription
                }
            };

		}        
        
    }
}


