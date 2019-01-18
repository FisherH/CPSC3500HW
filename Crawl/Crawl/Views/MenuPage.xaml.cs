using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

        async void HistoryPageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage());
        }

        async void CharactersPageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        async void ItemsPageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

    }
}