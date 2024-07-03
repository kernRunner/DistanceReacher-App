using DistanceReacher.Models.Favorite;
using DistanceReacher.Services;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DistanceReacher.ViewModels
{
    internal class FavoriteViewModel : ObservableObject, INotifyPropertyChanged
    {
        public static FavoriteViewModel Current { get; private set; }

        private SQLiteConnection connection;
        private string selectedLocation;
        private ObservableCollection<FavoriteModel> filteredFavorites;
        private ObservableCollection<FavoriteModel> favorites;

        public FavoriteViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
            Favorites = new ObservableCollection<FavoriteModel>(connection.Table<FavoriteModel>().ToList());

            // Ensure the Locations collection is initialized and populated
            Locations = new ObservableCollection<string>();
            FilteredFavorites = new ObservableCollection<FavoriteModel>(Favorites);
            UpdateLocations();

            // Set the default location to "All" and trigger filtering
            SelectedLocation = "All"; // Default value for the picker
            FilterFavorites();
        }

        public ObservableCollection<FavoriteModel> Favorites
        {
            get { return favorites; }
            set
            {
                favorites = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEmpty));
            }
        }

        public ObservableCollection<FavoriteModel> FilteredFavorites
        {
            get => filteredFavorites;
            set { filteredFavorites = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Locations { get; set; }

        public string SelectedLocation
        {
            get => selectedLocation;
            set
            {
                if (selectedLocation != value)
                {
                    selectedLocation = value;
                    OnPropertyChanged();
                    FilterFavorites();
                }
            }
        }

        public bool IsEmpty => !Favorites.Any();

        private void FilterFavorites()
        {
            if (SelectedLocation == "All")
            {
                FilteredFavorites = new ObservableCollection<FavoriteModel>(Favorites);
            }
            else
            {
                FilteredFavorites = new ObservableCollection<FavoriteModel>(Favorites.Where(f => f.Location == SelectedLocation));
            }
        }

        public void UpdateLocations()
        {
            Locations.Clear();
            Locations.Add("All");
            var distinctLocations = Favorites.Select(f => f.Location).Distinct();
            foreach (var location in distinctLocations)
            {
                Locations.Add(location);
            }
        }

        public bool IsFavorite(string name)
        {
            return connection.Table<FavoriteModel>().Any(f => f.FavName == name);
        }

        public void SaveCharacter(FavoriteModel model)
        {
            Console.WriteLine(model.Location);

            // Check if the item with the same name already exists in the database
            var existingItem = connection.Table<FavoriteModel>().FirstOrDefault(f => f.FavName == model.FavName);
            if (existingItem != null)
            {
                // If it exists, update the existing item
                model.Id = existingItem.Id; // Ensure the correct ID is used for the update
                connection.Update(model);
            }
            else
            {
                // If not, it's new and we need to add it
                connection.Insert(model);
            }

            UpdateFavoritesCollection();
        }

        public void DeleteCharacter(FavoriteModel model)
        {
            // Check if the item with the same name exists in the database
            var existingItem = connection.Table<FavoriteModel>().FirstOrDefault(f => f.FavName == model.FavName);
            if (existingItem != null)
            {
                // If it exists, delete the item
                connection.Delete(existingItem);
            }

            UpdateFavoritesCollection();
        }

        private void UpdateFavoritesCollection()
        {
            Favorites = new ObservableCollection<FavoriteModel>(connection.Table<FavoriteModel>().ToList());
            UpdateLocations();
            FilterFavorites();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(Favorites))
            {
                OnPropertyChanged(nameof(IsEmpty));
            }
        }
    }
}
