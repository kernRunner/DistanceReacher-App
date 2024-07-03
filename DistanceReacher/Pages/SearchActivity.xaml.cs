using DistanceReacher.Models.MeilisearchActvity;
using DistanceReacher.SubPages;

namespace DistanceReacher.Pages;

public partial class SearchActivity : ContentPage
{
	public SearchActivity()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Details.LoadSearchAct("");

        var classInfo = Details._searchActInfos;
        yourListView1.ItemsSource = classInfo;
    }


    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var newText = e.NewTextValue; // This is what the user has typed
        await Details.LoadSearchAct(newText);

        var classInfo = Details._searchActInfos;
        yourListView1.ItemsSource = classInfo;
    }


    private void OnItemTapped(object sender, EventArgs e)
    {
        var tappedEventArgs = e as TappedEventArgs;
        var url = tappedEventArgs.Parameter as string;

        if (!string.IsNullOrEmpty(url))
        {
            try
            {
                Launcher.OpenAsync(new Uri(url));
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }


}