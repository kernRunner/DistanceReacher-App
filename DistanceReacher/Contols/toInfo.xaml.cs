using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using DistanceReacher.SubPages;
using DistanceReacher.Pages;

namespace DistanceReacher.Contols;

public partial class toInfo : ContentView
{
	public toInfo()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty NameProperty =
    BindableProperty.Create(nameof(Name), typeof(string), typeof(toInfo), string.Empty);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(toInfo), string.Empty);

    public static readonly BindableProperty ImgProperty =
        BindableProperty.Create(nameof(Img), typeof(string), typeof(toInfo), string.Empty);

    public static readonly BindableProperty DetailProperty =
    BindableProperty.Create(nameof(Detail), typeof(Array), typeof(toInfo));

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

    public Array Detail
    {
        get { return (Array)GetValue(DetailProperty); }
        set { SetValue(DetailProperty, value); }
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TravelInfo(Name, Text, Img, Detail));
    }
}