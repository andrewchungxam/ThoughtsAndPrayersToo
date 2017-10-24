using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using ThoughtsAndPrayersTooTemplate.ViewModels;
using ThoughtsAndPrayersTooTemplate.Models;

namespace ThoughtsAndPrayersTooShared.Views
{
    public class ItemsPage : ContentPage
    {
        ListView _itemsListView;
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            _viewModel = new ItemsViewModel();
            BindingContext = _viewModel;

			ToolbarItem clickToSave = new ToolbarItem()
			{
				Text = "Add",
			};

            clickToSave.Clicked += AddItem_Clicked;

            this.ToolbarItems.Add(clickToSave);

			   _itemsListView = new ListView(ListViewCachingStrategy.RecycleElement) {
                HasUnevenRows = true,
                IsPullToRefreshEnabled = true,
                VerticalOptions = LayoutOptions.FillAndExpand
			};


			var dataTemplate = new DataTemplate(() =>
			{
                Label textCellLabel = new Label() 
                {
					FontSize = 16,
                    Style = Device.Styles.ListItemTextStyle

				};
                textCellLabel.SetBinding(Label.TextProperty, "Text");

				Label detailCellLabel = new Label()
				{
                    FontSize = 13,
                    Style = Device.Styles.ListItemDetailTextStyle
				};
                detailCellLabel.SetBinding(Label.TextProperty, "Description");

                var cellStackLayout = new StackLayout()
                {
                    Padding = new Thickness(10),
                    Children =
                    {
                        textCellLabel,
                        detailCellLabel
                    }
                };

                return new ViewCell { View = cellStackLayout };

			});

			_itemsListView.SetBinding(ListView.RefreshCommandProperty, "LoadItemsCommand");
			_itemsListView.SetBinding(ListView.IsRefreshingProperty, "IsBusy", BindingMode.OneWay);
			_itemsListView.SetBinding(ListView.ItemsSourceProperty, "Items");

			_itemsListView.ItemSelected += OnItemSelected;
			_itemsListView.ItemTemplate = dataTemplate;

			Content = _itemsListView;
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			_itemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel.Items.Count == 0)
				_viewModel.LoadItemsCommand.Execute(null);
		}
	}
}