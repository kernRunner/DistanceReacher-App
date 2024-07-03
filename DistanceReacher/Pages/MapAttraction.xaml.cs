using DistanceReacher.Models.Attraction;
using DistanceReacher.Models.Hotspot;
using DistanceReacher.Models.maps;
using DistanceReacher.SubPages;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Windows.Input;

namespace DistanceReacher.Pages;

public partial class MapAttraction : ContentPage
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

    private bool _useAttractions = false; // Boolean field to toggle data sources

    private string _buttonText;
    public string ButtonText
    {
        get { return _buttonText; }
        set { _buttonText = value; OnPropertyChanged(); }
    }

    public MapAttraction()
    {
        InitializeComponent();
        OpenDetailsCommand = new Command(OpenDetailsOrHotspot); // Bind to new method
        BindingContext = this;

        ButtonText = "To Attraction";
        LoadHotspotsOnMap();
    }

    private async Task LoadHotspotsOnMap() // Change return type to Task
    {
        if (_useAttractions)
        {
            await AttractionDetails.LoadAttractions();
            var hotspotsInfo = AttractionDetails.Attractions;
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
        }
        else
        {
            await HotspotDetails.LoadHotspots();
            var hotspotsInfo = HotspotDetails.Hotspots;
            Pins = hotspotsInfo.Select(hotspot => new MapPin(MapPinClicked)
            {
                Id = Guid.NewGuid().ToString(),
                Position = new Location(hotspot.Latitude, hotspot.Longitude),
                Icon = "mappin",
                Title = hotspot.Name,
                Description = hotspot.Description,
                Image = hotspot.Image,
            }).ToList();
            Console.WriteLine(Pins);
        }

        // Geolocation and map movement code
        var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
        var location = new Location(-25.3444, 131.0369);

        // Move the MapEx control to the specified region
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(3000)));
    }

    private void MapPinClicked(MapPin pin)
    {
        SelectedPin = pin;
        PinInfoOverlay.IsVisible = true;
        Console.WriteLine($"Pin clicked: {pin.Title}");
    }

    private async void OpenDetailsOrHotspot()
    {
        if (_useAttractions)
        {
            await OpenDetails();
        }
        else
        {
            await OpenHotspot();
        }
    }

    private async Task OpenDetails()
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

    private async Task OpenHotspot()
    {
        Console.WriteLine("OpenDetails command executed");
        if (SelectedPin != null)
        {
            Console.WriteLine($"Navigating to details page for: {SelectedPin.Title}");
            await Navigation.PushAsync(new Hotspot(SelectedPin.Title));
        }
        else
        {
            Console.WriteLine("SelectedPin is null");
        }
    }

    private async void changeData(object sender, EventArgs e)
    {
        _useAttractions = !_useAttractions; // Toggle the boolean field
        ButtonText = _useAttractions ? "To Hotspots" : "To Attractionss"; // Update button text
        PinInfoOverlay.IsVisible = false;
        await LoadHotspotsOnMap(); // Reload hotspots with the new data source
    }

    private void OnContentViewTapped(object sender, TappedEventArgs e)
    {
        // If the overlay is visible and the tap is outside of it, hide the overlay
        if (PinInfoOverlay.IsVisible)
        {
            PinInfoOverlay.IsVisible = false;
        }
    }
}
