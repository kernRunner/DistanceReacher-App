namespace DistanceReacher.SubPages;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
		InitializeComponent();
    }

    private async void OnBackButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}