using System;
using ThoughtsAndPrayersTooTemplate.Models;

namespace ThoughtsAndPrayersTooTemplate.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }

		//#TODO - you can either modify the Binding Context of the item Description Label or make Description a public property on the ItemDetailViewModel
		//If you choose this method you have to add the description property in th eItemDetailViewModel constructor
        //public string Description { get; set; }

		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = item;
        //    Description = item?.Description;
		}
	}
}
