using DistanceReacher.SubPages;

namespace DistanceReacher.Pages;

public partial class HomeScreen : ContentPage
{
	public HomeScreen()
	{
		InitializeComponent();
    }


    private async void toMap(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mapattraction");
    }

    private async void ToSearchPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//searchpage");
    }
    private async void toFavorite(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//favoritepage");
    }
    private async void toActvity(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//searchpageActivity");
    }

    private void toWelcome(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Welcome());
    }
    private void toHotspot(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Hotspot("Sydney"));
    }
    private void toHotspot1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Hotspot("Victoria"));
    }
    private void toHotspot2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Hotspot("Queensland"));
    }
    private void toHotspot3(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Country("Australia"));
    }



}