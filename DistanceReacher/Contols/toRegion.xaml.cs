
using DistanceReacher.SubPages;
using Microsoft.Maui;
using DistanceReacher.Pages;
using DistanceReacher.ViewModels;
using DistanceReacher.Models.Favorite;

namespace DistanceReacher.Contols;

public partial class toRegion : ContentView
{
    public toRegion()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(toPlace), string.Empty);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(toPlace), string.Empty);

    public static readonly BindableProperty ImgProperty =
        BindableProperty.Create(nameof(Img), typeof(string), typeof(toPlace), string.Empty);

    public static readonly BindableProperty IndexProperty =
        BindableProperty.Create(nameof(Index), typeof(int), typeof(toPlace), 0);


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


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Hotspot(Name));
    }

}