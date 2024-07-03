using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Models.MeilisearchActvity
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
        public string u_id { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string img_link { get; set; }
        public string title { get; set; }
        public float rating { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public Hotspot[] hotspots { get; set; }
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







}
