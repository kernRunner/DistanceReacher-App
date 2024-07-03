using System.Xml;
using DistanceReacher.Models;
namespace DistanceReacher.SubPages;

public partial class Place : ContentPage
{


    public Place(string name, string text, string img)
	{

        InitializeComponent();

        nameLabel.Text = name;
        textLabel.Text = text;
        image.Source = img;

    }

    private async void toMap(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mapattraction");
    }

}