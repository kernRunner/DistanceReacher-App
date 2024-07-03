using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Models.Hotspot
{

    internal class ApiHotspotModel
    {
        public int id { get; set; }
        public AttributesHotspot attributes { get; set; }
    }

    public class AttributesHotspot
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string type { get; set; }
        public Image image { get; set; }
        public Attractions attractions { get; set; }
        public Activities activities { get; set; }
    }

    public class Image
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public Attributes1 attributes { get; set; }
    }

    public class Attributes1
    {
        public string name { get; set; }
        public string alternativeText { get; set; }
        public object caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Formats formats { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public float size { get; set; }
        public string url { get; set; }
        public object previewUrl { get; set; }
        public string provider { get; set; }
        public object provider_metadata { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Formats
    {
        public Small small { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Small
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public float size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sizeInBytes { get; set; }
    }

    public class Thumbnail
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public float size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sizeInBytes { get; set; }
    }

    public class Attractions
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public Attributes2 attributes { get; set; }
    }

    public class Attributes2
    {
        public string name { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public string _ref { get; set; }
        public bool more { get; set; }
        public Image1 image { get; set; }
    }

    public class Image1
    {
        public Data1 data { get; set; }
    }

    public class Data1
    {
        public int id { get; set; }
        public Attributes3 attributes { get; set; }
    }

    public class Attributes3
    {
        public string name { get; set; }
        public string alternativeText { get; set; }
        public object caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Formats1 formats { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public float size { get; set; }
        public string url { get; set; }
        public object previewUrl { get; set; }
        public string provider { get; set; }
        public object provider_metadata { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Formats1
    {
        public Small1 small { get; set; }
        public Thumbnail1 thumbnail { get; set; }
    }

    public class Small1
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public float size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sizeInBytes { get; set; }
    }

    public class Thumbnail1
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public float size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sizeInBytes { get; set; }
    }

    public class Activities
    {
        public Datum2[] data { get; set; }
    }

    public class Datum2
    {
        public int id { get; set; }
        public Attributes4 attributes { get; set; }
    }

    public class Attributes4
    {
        public string u_id { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string img_link { get; set; }
        public string title { get; set; }
        public float rating { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
    }





}
