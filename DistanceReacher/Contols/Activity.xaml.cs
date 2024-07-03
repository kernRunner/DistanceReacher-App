using System.Windows.Input;

namespace DistanceReacher.Contols;

public partial class Activity : ContentView
{
    public Activity()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty BookUrlProperty =
        BindableProperty.Create(nameof(BookUrl), typeof(string), typeof(Activity), string.Empty);

    public string BookUrl
    {
        get => (string)GetValue(BookUrlProperty);
        set => SetValue(BookUrlProperty, value);
    }

    private void OnBookNowButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(BookUrl))
        {
            return;
        }

        try
        {
            Launcher.OpenAsync(new Uri(BookUrl));
        }
        catch (Exception ex)
        {

        }
    }
}