using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;


namespace DistanceReacher.Models.Favorite
{
    [Table("favorites")]

    public class FavoriteModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Index { get; set; }
        public string FavName { get; set; }
        public string Location { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
    }


}
