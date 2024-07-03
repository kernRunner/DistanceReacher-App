using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DistanceReacher.Models.maps
{
    public class MapPin
    {
        public string Id { get; set; }
        public Location Position { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public ICommand ClickedCommand { get; set; }

        public MapPin(Action<MapPin> clicked)
        {
            ClickedCommand = new Command(() => clicked(this));
        }
    }
}
