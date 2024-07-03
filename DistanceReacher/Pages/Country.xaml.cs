using System.Collections.ObjectModel;
using System.Xml.Linq;
using DistanceReacher.Models;
using DistanceReacher.Models.Country;
using DistanceReacher.SubPages;
using static System.Net.Mime.MediaTypeNames;

namespace DistanceReacher.Pages;


public partial class Country : ContentPage
{



    public Country(string name)
    {
        BindingContext = this;
        InitializeComponent();

        Items = new List<string>
            {
                "Entry 1",
                "Entry 2",
                "Entry 3",
                "Entry 4",
                "Entry 5"
            };

        //var filePath = Path.Combine(FileSystem.AppDataDirectory, "Resources/Images/australiamap.svg");
        //svgImage.LoadSvgFromFile(filePath);
        //svgImage.GroupClicked += OnSvgGroupClicked;

    }


    //private void OnSvgGroupClicked(object sender, string groupName)
    //{
    //    DisplayAlert("Group Clicked", $"You clicked on group: {groupName}", "OK");
    //}

    protected override async void OnAppearing()
    {

        base.OnAppearing();
        await CountryDetails.LoadCountryHotspots(null);
        await CountryDetails.LoadCountryInfos();

        var classInfoCity = new object[0];
        classInfoCity = CountryDetails.Citys;

        var classInfos = new object[0];
        classInfos = CountryDetails.Infos;

        yourListView1.ItemsSource = classInfoCity;
        listViewRegion.ItemsSource = CountryDetails.Regions;

        Name.Text = CountryDetails.Countrys[0].Name;
        Description.Text = CountryDetails.Countrys[0].Description;
        ImageSrc.Source = ImageSource.FromUri(new Uri(CountryDetails.Countrys[0].Image));


        title1.Text = CountryDetails.Infos[0].Name;
        imgSource1.Source = CountryDetails.Infos[0].Image;

        title2.Text = CountryDetails.Infos[1].Name;
        imgSource2.Source = CountryDetails.Infos[1].Image;

        title3.Text = CountryDetails.Infos[2].Name;
        imgSource3.Source = CountryDetails.Infos[2].Image;

        title4.Text = CountryDetails.Infos[3].Name;
        imgSource4.Source = CountryDetails.Infos[3].Image;

        title5.Text = CountryDetails.Infos[4].Name;
        imgSource5.Source = CountryDetails.Infos[4].Image;




        BindingContext = this;
    }

    private async void toMap(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mapattraction");
    }

    public List<string> Items { get; }


    private void ViewButton_Clicked(object sender, EventArgs e)
    {

    }

    private void travelInfoPage(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(CountryDetails.Infos[0].Name, CountryDetails.Infos[0].Description, "Test", CountryDetails.Infos[0].Detail));
    }
    private void travelInfoPage1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(CountryDetails.Infos[1].Name, CountryDetails.Infos[1].Description, "Test", CountryDetails.Infos[1].Detail));
    }
    private void travelInfoPage2(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(CountryDetails.Infos[2].Name, CountryDetails.Infos[2].Description, "Test", CountryDetails.Infos[2].Detail));
    }
    private void travelInfoPage3(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(CountryDetails.Infos[3].Name, CountryDetails.Infos[3].Description, "Test", CountryDetails.Infos[3].Detail));
    }
    private void travelInfoPage4(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(CountryDetails.Infos[4].Name, CountryDetails.Infos[4].Description, "Test", CountryDetails.Infos[4].Detail));
    }

}