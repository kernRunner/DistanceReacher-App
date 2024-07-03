using static System.Net.Mime.MediaTypeNames;

namespace DistanceReacher.SubPages;

public partial class TravelInfo : ContentPage
{
	public TravelInfo(string name, string description, string img, Array detail)
	{
		InitializeComponent();

        nameLabel.Text = name;
        descriptionLabel.Text = description;

        ListViewDetails.ItemsSource = detail;
    }
}