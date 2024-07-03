using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Models.Meilisearch
{

    internal class ApiMeilisearchModel
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string indexUid { get; set; }
        public Hit[] hits { get; set; }
        public string query { get; set; }
        public int processingTimeMs { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int estimatedTotalHits { get; set; }
    }

    public class Hit
    {
        public string _meilisearch_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public bool more { get; set; }
        public string title { get; set; }
        public string alt { get; set; }
        public Image image { get; set; }
        public Hotspot hotspot { get; set; }
        public string type { get; set; }
        public Country country { get; set; }
        public Attraction[] attractions { get; set; }
        public object top_hotspot { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternativeText { get; set; }
        public string caption { get; set; }
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
        public string folderPath { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Formats
    {
        public Large large { get; set; }
        public Small small { get; set; }
        public Medium medium { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Large
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

    public class Medium
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

    public class Hotspot
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string type { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
    }

    public class Attraction
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public bool more { get; set; }
        public string title { get; set; }
        public string alt { get; set; }
    }



}
