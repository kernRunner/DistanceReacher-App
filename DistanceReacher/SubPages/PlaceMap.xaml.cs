using System.Xml;
using DistanceReacher.Pages;


namespace DistanceReacher.SubPages;

public partial class PlaceMap : ContentPage
{
    private readonly string _hotspot;

    public PlaceMap(string name, string text, string img, string hotspot)
	{

        InitializeComponent();

        nameLabel.Text = name;
        textLabel.Text = text;
        image.Source = img;
        hotspotname.Text = "Discover more about " + hotspot;

        _hotspot = hotspot;

    }

    private void toMap(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Hotspot(_hotspot));
    }


}