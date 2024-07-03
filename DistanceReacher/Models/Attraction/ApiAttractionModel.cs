using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Models.Attraction
{

    internal class ApiAttractionModel
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public string name { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string _ref { get; set; }
        public bool more { get; set; }
        public Hotspot hotspot { get; set; }
        public ImageAttraction image { get; set; }
    }

    public class Hotspot
    {
        public DataHotspot data { get; set; }
    }

    public class DataHotspot
    {
        public int id { get; set; }
        public AttributesSingleHotspot attributes { get; set; }
    }

    public class AttributesSingleHotspot
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class ImageAttraction
    {
        public DataAttraction data { get; set; }
    }

    public class DataAttraction
    {
        public int id { get; set; }
        public AttributesAttraction attributes { get; set; }
    }

    public class AttributesAttraction
    {
        public string url { get; set; }
    }



    public class Rootobject
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
    }







}
