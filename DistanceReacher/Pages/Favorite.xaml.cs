using DistanceReacher.Models.Favorite;
using DistanceReacher.ViewModels;


namespace DistanceReacher.Pages;

public partial class Favorite : ContentPage
{
    private FavoriteViewModel viewModel;

    public Favorite()
    {
        InitializeComponent();
        BindingContext = viewModel = new FavoriteViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Refresh the list and locations when the page appears
        viewModel.OnPropertyChanged(nameof(viewModel.Favorites));
        viewModel.UpdateLocations();
        viewModel.SelectedLocation = "All";
        UpdateEmptyLayoutVisibility();
    }

    private async void toHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainpage");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var itemName = button?.CommandParameter as string;

        if (string.IsNullOrEmpty(itemName))
        {
            await DisplayAlert("Error", "Item name is not set", "OK");
            return;
        }

        var model = new FavoriteModel
        {
            FavName = itemName
        };

        try
        {
            FavoriteViewModel.Current.DeleteCharacter(model);
            await DisplayAlert("Success", "Item deleted successfully: " + itemName, "OK");


            // Refresh the list after deletion
            viewModel.OnPropertyChanged(nameof(viewModel.Favorites));
            viewModel.UpdateLocations();
            viewModel.SelectedLocation = "All";
            UpdateEmptyLayoutVisibility();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void UpdateEmptyLayoutVisibility()
    {
        EmptyLayout.IsVisible = !viewModel.Favorites.Any();
    }
}