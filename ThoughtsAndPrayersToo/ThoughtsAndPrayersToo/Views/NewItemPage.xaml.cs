using System;

using Xamarin.Forms;

namespace ThoughtsAndPrayersToo
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

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
            itemTextEntry.SetBinding(Entry.TextProperty, Item.Text);

			Label descriptionLabel = new Label()
			{
				Text = "Description",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};

            Editor editorText = new Editor()
            {
                Text = Item.Description,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Editor)),
                Margin = new Thickness(0)
            };

			BindingContext = this.Item;

			Content = new StackLayout()
            {
                Spacing= 20,
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
