using DistanceReacher.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DistanceReacher.Models.MeilisearchActvity
{
    class Details
    {

        public class SearchInfo
        {
            public string title { get; set; }
            public string link { get; set; }
            public string img_link { get; set; }
            public string description { get; set; }
            public string location { get; set; }

        }

        public static SearchInfo[] _searchActInfos;
        public static SearchInfo[] SearchActInfos
        {
            get
            {
                if (_searchActInfos != null)
                    return _searchActInfos;
                else
                    return new SearchInfo[0];
            }
            set
            {
                _searchActInfos = value;
            }
        }

        public static async Task LoadSearchAct(string keyword)
        {
            Console.WriteLine(keyword);
            Console.WriteLine(keyword);
            Console.WriteLine(keyword);
            try
            {
                string json = await ApiServiceDR.PostActivityWithBearerTokenAsync(keyword);
                var response = JsonConvert.DeserializeObject<ApiMeilisearchModel>(json);

                if (response.results != null)
                {
                    List<SearchInfo> hotspotNames = new List<SearchInfo>();
                    for (int i = 0; i < response.results.Length; i++)
                    {
                        for (int j = 0; j < response.results[i].hits.Length; j++)
                        {

                            SearchInfo hotInfo = new SearchInfo
                            {
                                title = response.results[i].hits[j].title,
                                link = response.results[i].hits[j].link,
                                img_link = response.results[i].hits[j].img_link,
                                description = response.results[i].hits[j].description,
                                location = response.results[i].hits[j].hotspots[0].name,
                            };
                            hotspotNames.Add(hotInfo);

                        }

                    }
                    _searchActInfos = hotspotNames.ToArray();
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");

            }


        }


    }
}
