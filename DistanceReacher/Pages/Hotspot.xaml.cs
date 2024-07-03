using DistanceReacher.Models.Favorite;
using DistanceReacher.Models.Hotspot;
using DistanceReacher.Models.Meilisearch;
using DistanceReacher.Services;
using DistanceReacher.SubPages;
using DistanceReacher.ViewModels;


namespace DistanceReacher.Pages;

public partial class Hotspot : ContentPage
{
    private string name;


    public Hotspot(string name)
    {
        this.name = name;
        InitializeComponent();

        // Ensure FavoriteViewModel is initialized
        if (FavoriteViewModel.Current == null)
        {
            new FavoriteViewModel();
        }

        // Set the initial BindingContext
        BindingContext = new FavoriteModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await HotspotDetails.LoadHotspotAttactions(name);
        await HotspotDetails.LoadActivity(name);

        var classInfo = new object[0];
        classInfo = HotspotDetails.Attractions;

        var activityInfo = new object[0];
        activityInfo = HotspotDetails.Activities;

        yourListView1.ItemsSource = classInfo;
        //yourListView111.ItemsSource = classInfo;
        yourListView2.ItemsSource = activityInfo;

        Name.Text = HotspotDetails.Hotspot[0].Name;
        Description.Text = HotspotDetails.Hotspot[0].Description;
        ImageSrc.Source = ImageSource.FromUri(new Uri(HotspotDetails.Hotspot[0].Image));
    }

    private void toMap(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new MapPage("region", HotspotDetails.Hotspot[0].Name));
        Navigation.PushAsync(new CustomMapAttr(name));
    }

    private async void JumpToAttraction(object sender, EventArgs e)
    {
        await BodyScroll.ScrollToAsync(anchorAttraction, ScrollToPosition.Start, true);
    }

    private async void JumpToMap(object sender, EventArgs e)
    {
        await BodyScroll.ScrollToAsync(anchorMap, ScrollToPosition.Start, true);
    }

    private async void JumpToActivity(object sender, EventArgs e)
    {
        await BodyScroll.ScrollToAsync(anchorActivity, ScrollToPosition.Start, true);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var model = BindingContext as FavoriteModel;
        if (model == null)
        {
            await DisplayAlert("Error", "BindingContext is not set", "OK");
            return;
        }

        Console.WriteLine(model.FavName);
        Console.WriteLine(model.Description);
        if (string.IsNullOrWhiteSpace(model.FavName))
        {
            await DisplayAlert("Warning", "You must enter a name before saving a character", "OK");
            return;
        }

        try
        {
            FavoriteViewModel.Current.SaveCharacter(model);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var itemId = button?.CommandParameter as int?;

        if (!itemId.HasValue)
        {
            await DisplayAlert("Error", "Item ID is not set", "OK");
            return;
        }

        var model = new FavoriteModel
        {
            Id = itemId.Value
        };

        try
        {
            FavoriteViewModel.Current.DeleteCharacter(model);
            await DisplayAlert("Success", "Item deleted successfully", "OK");

            // Refresh the list after deletion
            //yourListView111.ItemsSource = HotspotDetails.Attractions.Where(item => item.Id != model.Id).ToList();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }



    private async void ToAttraction(object sender, EventArgs e)
    {
        var button = sender as Button;
        var itemId = button?.CommandParameter as int?;

        if (!itemId.HasValue)
        {
            await DisplayAlert("Error", "Item ID is not set", "OK");
            return;
        }

        await Navigation.PushAsync(new Place(HotspotDetails.Attractions[itemId.Value].Name, HotspotDetails.Attractions[itemId.Value].Description, HotspotDetails.Attractions[itemId.Value].Image));
    }


    private async void HeartButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var itemId = button?.CommandParameter as int?;

        if (!itemId.HasValue)
        {
            await DisplayAlert("Error", "Item ID is not set", "OK");
            return;
        }

        var model = new FavoriteModel { 
            FavName = HotspotDetails.Attractions[itemId.Value].Name,
            Description = HotspotDetails.Attractions[itemId.Value].Description,
            Location = HotspotDetails.Attractions[itemId.Value].Name,
            Img = HotspotDetails.Attractions[itemId.Value].Image,
            Index = itemId.Value
        };

        try
        {
            FavoriteViewModel.Current.SaveCharacter(model);
            await DisplayAlert("Success", "Item saved successfully", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
