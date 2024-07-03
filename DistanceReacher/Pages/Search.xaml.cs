using System.Xml.Linq;
using DistanceReacher.Models.Meilisearch;

using static System.Net.Mime.MediaTypeNames;
using DistanceReacher.SubPages;
using DistanceReacher.Models.Attraction;

namespace DistanceReacher.Pages;

public partial class Search : ContentPage
{
    public Search()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await AttractionDetails.LoadAttractions();
        await Details.LoadSearch("");

        var classInfo = Details._searchInfos;
        yourListView1.ItemsSource = classInfo;
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var newText = e.NewTextValue; // This is what the user has typed
        await Details.LoadSearch(newText);

        var classInfo = Details._searchInfos;
        yourListView1.ItemsSource = classInfo;
    }

    private void TapGestureRecognizer_Seach(object sender, EventArgs e)
    {
        var tappedEventArgs = e as TappedEventArgs;
        if (tappedEventArgs != null)
        {
            var tappedItem = tappedEventArgs.Parameter as int?;
            Console.WriteLine(tappedEventArgs);
            Console.WriteLine(tappedItem);

            if (tappedItem.HasValue)
            {
                int itemId = tappedItem.Value;

                if (Details.SearchInfos[itemId].Type == "Attraction")
                {
                    Navigation.PushAsync(new PlaceMap(Details.SearchInfos[itemId].Name, Details.SearchInfos[itemId].Description, Details.SearchInfos[itemId].Image, Details.SearchInfos[itemId].Path));
                }
                else if (Details.SearchInfos[itemId].Type == "Hotspot")
                {
                    Navigation.PushAsync(new Hotspot(Details.SearchInfos[itemId].Name));
                }
            }
        }
    }

    // Example item class, replace with your actual item class
    public class SearchInfo
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

}
