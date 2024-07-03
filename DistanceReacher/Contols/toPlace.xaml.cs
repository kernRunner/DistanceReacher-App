
using DistanceReacher.SubPages;
using Microsoft.Maui;
using DistanceReacher.Pages;
using DistanceReacher.ViewModels;
using DistanceReacher.Models.Favorite;

namespace DistanceReacher.Contols;

public partial class toPlace : ContentView
{
    public toPlace()
    {
        InitializeComponent();
        UpdateFavoriteStatus();
    }

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(toPlace), string.Empty, propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(toPlace), string.Empty, propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty ImgProperty =
        BindableProperty.Create(nameof(Img), typeof(string), typeof(toPlace), string.Empty, propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty IndexProperty =
        BindableProperty.Create(nameof(Index), typeof(int), typeof(toPlace), 0, propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty TypePageProperty =
        BindableProperty.Create(nameof(TypePage), typeof(string), typeof(toPlace), string.Empty, propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(nameof(Location), typeof(string), typeof(toPlace), string.Empty, propertyChanged: OnPropertyChanged);

    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public string Img
    {
        get { return (string)GetValue(ImgProperty); }
        set { SetValue(ImgProperty, value); }
    }

    public int Index
    {
        get { return (int)GetValue(IndexProperty); }
        set { SetValue(IndexProperty, value); }
    }

    public string TypePage
    {
        get { return (string)GetValue(TypePageProperty); }
        set { SetValue(TypePageProperty, value); }
    }

    public string Location
    {
        get { return (string)GetValue(LocationProperty); }
        set { SetValue(LocationProperty, value); }
    }

    private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (toPlace)bindable;
        control.UpdateFavoriteStatus();
    }

    private void UpdateFavoriteStatus()
    {
        if (!string.IsNullOrEmpty(Name))
        {
            var isFavorite = FavoriteViewModel.Current.IsFavorite(Name);
            Console.WriteLine($"IsFavorite: {isFavorite}, Name: {Name}");
            FavoriteButton.IsVisible = isFavorite;
            NotFavoriteButton.IsVisible = !isFavorite;
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (TypePage == "place")
        {
            Navigation.PushAsync(new Place(Name, Text, Img));
        }
        else
        {
            Navigation.PushAsync(new Hotspot(Name));
        }
    }

    private void AddFavorite(object sender, EventArgs e)
    {
        var model = new FavoriteModel
        {
            FavName = Name,
            Description = Text,
            Location = Location,
            Img = Img,
            Index = Index
        };

        try
        {
            FavoriteViewModel.Current.SaveCharacter(model);
            FavoriteButton.IsVisible = true;
            NotFavoriteButton.IsVisible = false;
        }
        catch (Exception ex)
        {
        }
    }

    private void RemoveFavorite(object sender, EventArgs e)
    {
        var model = new FavoriteModel
        {
            FavName = Name,
            Description = Text,
            Location = Location,
            Img = Img,
            Index = Index
        };

        try
        {
            FavoriteViewModel.Current.DeleteCharacter(model);
            FavoriteButton.IsVisible = false;
            NotFavoriteButton.IsVisible = true;
        }
        catch (Exception ex)
        {
        }
    }
}