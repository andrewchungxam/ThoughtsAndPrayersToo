using System;
using System.Diagnostics;
using ThoughtsAndPrayersTooTemplate.Models;
using Xamarin.Forms;

namespace ThoughtsAndPrayersTooShared.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }
        public string Text { get; set; }
        public string Description { get; set;}

		public NewItemPage()
		{
			this.Title = "New Item";

			ToolbarItem clickToSave = new ToolbarItem()
			{
				Text = "Save"
			};
			clickToSave.Clicked += Save_Clicked;

			this.ToolbarItems.Add(clickToSave);

			Item = new Item
			{
				Text = "Item name",
				Description = "This is an item description."
			};


			Label textLabel = new Label()
			{
				Text = "Text",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};

			Entry itemTextEntry = new Entry()
			{
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry))
			};
			itemTextEntry.SetBinding(Entry.TextProperty, new Binding("Item.Text", BindingMode.TwoWay));

			Label descriptionLabel = new Label()
			{
				Text = "Description",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};

			Editor editorText = new Editor()
			{
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Editor)),
				Margin = new Thickness(0)
			};
			editorText.SetBinding(Editor.TextProperty, new Binding("Item.Description", BindingMode.TwoWay));

			BindingContext = this;

			Content = new StackLayout()
			{
				Spacing = 20,
				Padding = new Thickness(15),
				Children =
				{
					textLabel,
					itemTextEntry,
					descriptionLabel,
					editorText
				}
			};
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopToRootAsync();
		}
	}
}




