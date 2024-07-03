using DistanceReacher.Models.Hotspot;
using DistanceReacher.Models.maps;
using DistanceReacher.SubPages;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Windows.Input;

namespace DistanceReacher.Pages;

public partial class CustomMapAttr : ContentPage
{
    private List<MapPin> _pins;
    public List<MapPin> Pins
    {
        get { return _pins; }
        set { _pins = value; OnPropertyChanged(); }
    }

    private MapPin _selectedPin;
    public MapPin SelectedPin
    {
        get { return _selectedPin; }
        set
        {
            _selectedPin = value;
            OnPropertyChanged();
            Console.WriteLine($"SelectedPin set to: {(_selectedPin != null ? _selectedPin.Title : "null")}");
        }
    }

    public ICommand OpenDetailsCommand { get; private set; }

    public CustomMapAttr(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            id = "Queensland";
        }

        LoadHotspots(id);

        InitializeComponent();
        OpenDetailsCommand = new Command(OpenDetails);



        BindingContext = this;
    }

    protected override void OnAppearing()
    {

    }

    private async void LoadHotspots(string id)
    {
        await HotspotDetails.LoadHotspotAttactions(id);
        var hotspotsInfo = HotspotDetails.Attractions;
        var hotspotsCord = HotspotDetails.Hotspot;

        var location = new Location(hotspotsCord[0].Latitude, hotspotsCord[0].Longitude);

        Pins = hotspotsInfo.Select(attraction => new MapPin(MapPinClicked)
        {
            Id = Guid.NewGuid().ToString(),
            Position = new Location(attraction.Latitude, attraction.Longitude),
            Icon = "mappin",
            Title = attraction.Name,
            Description = attraction.Description,
            Image = attraction.Image,
            Location = attraction.Hotspot,
        }).ToList();

        // Geolocation and map movement code
        var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));


        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1400)));
        Console.WriteLine(location);


        if (hotspotsCord[0].Type == "city")
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(10)));
        }


    }

    private void MapPinClicked(MapPin pin)
    {
        SelectedPin = pin;
        PinInfoOverlay.IsVisible = true;
        Console.WriteLine($"Pin clicked: {pin.Title}");
    }

    private async void OpenDetails()
    {
        Console.WriteLine("OpenDetails command executed");
        if (SelectedPin != null)
        {
            Console.WriteLine($"Navigating to details page for: {SelectedPin.Title}");
            await Navigation.PushAsync(new PlaceMap(SelectedPin.Title, SelectedPin.Description, SelectedPin.Image, SelectedPin.Location));
        }
        else
        {
            Console.WriteLine("SelectedPin is null");
        }
    }

    private async void to_Hotspot(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mappage");
    }
}