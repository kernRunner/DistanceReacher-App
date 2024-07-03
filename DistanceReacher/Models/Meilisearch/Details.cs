using DistanceReacher.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DistanceReacher.Models.Meilisearch
{
    class Details
    {

        public class SearchInfo
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Path { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }

        }

        public static SearchInfo[] _searchInfos;
        public static SearchInfo[] SearchInfos
        {
            get
            {
                if (_searchInfos != null)
                    return _searchInfos;
                else
                    return new SearchInfo[0];
            }
            set
            {
                _searchInfos = value;
            }
        }

        public static async Task LoadSearch(string keyword)
        {

            try
            {

                string json = await ApiServiceDR.PostDataWithBearerTokenAsync(keyword);
                var response = JsonConvert.DeserializeObject<ApiMeilisearchModel>(json);

                if (response.results != null)
                {
                    List<SearchInfo> hotspotNames = new List<SearchInfo>();
                    int value = 0;
                    for (int i = 0; i < response.results.Length; i++)
                    {
                        
                        for (int j = 0; j < response.results[i].hits.Length; j++)
                        {

                            if (response.results[i].indexUid == "hotspot")
                            {
                                value++;
                                SearchInfo hotInfo = new SearchInfo
                                {
                                    Index = j,
                                    Name = response.results[i].hits[j].name,
                                    Image = ApiServiceDR.BaseUrl + response.results[i].hits[j].image.url,
                                    Path = response.results[i].hits[j].country.name,
                                    Description = response.results[i].hits[j].country.description,
                                    Type = "Hotspot",
                                };
                                hotspotNames.Add(hotInfo);
                            }
                            else
                            {
                                SearchInfo hotInfo = new SearchInfo
                                {
                                    Index = j + value,
                                    Name = response.results[i].hits[j].name,
                                    Image = ApiServiceDR.BaseUrl + response.results[i].hits[j].image.url,
                                    Path = response.results[i].hits[j].hotspot.name,
                                    Description = response.results[i].hits[j].hotspot.description,
                                    Type = "Attraction",
                                };
                                hotspotNames.Add(hotInfo);
                            }
                            
                        }



                    }
                    _searchInfos = hotspotNames.ToArray();
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
