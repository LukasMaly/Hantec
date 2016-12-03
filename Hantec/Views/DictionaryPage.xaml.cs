using Xamarin.Forms;
using System.Collections.Generic;

namespace Hantec
{
	public partial class DictionaryPage : ContentPage
	{
		public DictionaryPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = App.Database.GetItemsOrdered();
		}

		void SearchBar_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			listView.ItemsSource = App.Database.GetWord(e.NewTextValue);
		}
	}
}

