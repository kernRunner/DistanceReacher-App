using DistanceReacher.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DistanceReacher.Models.Attraction
{
    public static class AttractionDetails
    {

        public class AttractionInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            // public string Ref { get; set; }
            //public bool More { get; set; }
            public string Hotspot { get; set; }
            public string Image { get; set; }
        }

        public static AttractionInfo[] _attractions;
        public static AttractionInfo[] Attractions
        {
            get
            {
                if (_attractions != null)
                    return _attractions;
                else
                    return new AttractionInfo[0];
            }
            set
            {
                _attractions = value;
            }
        }

        public static AttractionInfo[] _attractionsCity;
        public static AttractionInfo[] AttractionsCity
        {
            get
            {
                if (_attractionsCity != null)
                    return _attractionsCity;
                else
                    return new AttractionInfo[0];
            }
            set
            {
                _attractionsCity = value;
            }
        }

        public static AttractionInfo[] _attractionsRegion;
        public static AttractionInfo[] AttractionsRegion
        {
            get
            {
                if (_attractionsRegion != null)
                    return _attractionsRegion;
                else
                    return new AttractionInfo[0];
            }
            set
            {
                _attractionsRegion = value;
            }
        }

        public static async Task LoadAttractions()
        {
            string json = await ApiServiceDR.GetJsonFromAPI("attractions?fields[0]=name&fields[1]=description&fields[2]=lat&fields[3]=lng&fields[5]=more&populate[hotspot][fields][0]=name&populate[hotspot][fields][1]=type&populate[image][fields][0]=url");

            var response = JsonConvert.DeserializeObject<ApiAttractionResponse>(json);
            Console.WriteLine(response?.Data);
            Console.WriteLine(response);
            if (response?.Data != null)
            {
                List<AttractionInfo> attractionDataList = new List<AttractionInfo>();
                List<AttractionInfo> attractionDataListCity = new List<AttractionInfo>();
                List<AttractionInfo> attractionDataListRegion = new List<AttractionInfo>();
                for (int i = 0; i < response.Data.Length; i++)
                {
                    AttractionInfo attractionInfo = new AttractionInfo
                    {
                        Name = response.Data[i].attributes.name ?? "Default Name",
                        Description = response.Data[i].attributes.description ?? "Default Ref",
                        Latitude = response.Data[i].attributes?.lat ?? -33.8748f,
                        Longitude = response.Data[i].attributes?.lng ?? -33.8748f,
                        //Ref = response.Data[i].attributes._ref ?? "Default Ref",
                        //More = response.Data[i].attributes?.more ?? false,
                        Hotspot = response.Data[i].attributes.hotspot.data.attributes.name,
                        Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.image.data.attributes.url ?? "/uploads/sydney_4d43d2a172.jpeg",


                    };
                    if (response.Data[i].attributes.hotspot.data.attributes.type == "city")
                    {
                        AttractionInfo attractionInfoCity = new AttractionInfo
                        {
                            Name = response.Data[i].attributes.name ?? "Default Name",
                            Description = response.Data[i].attributes.description ?? "Default Ref",
                            Latitude = response.Data[i].attributes?.lat ?? -33.8748f,
                            Longitude = response.Data[i].attributes?.lng ?? -33.8748f,
                        };
                        attractionDataListCity.Add(attractionInfoCity);
                    }
                    else
                    {
                        AttractionInfo attractionInfoRegion = new AttractionInfo
                        {
                            Name = response.Data[i].attributes.name ?? "Default Name",
                            Description = response.Data[i].attributes.description ?? "Default Ref",
                            Latitude = response.Data[i].attributes?.lat ?? -33.8748f,
                            Longitude = response.Data[i].attributes?.lng ?? -33.8748f,
                        };
                        attractionDataListRegion.Add(attractionInfoRegion);
                    }

                    attractionDataList.Add(attractionInfo);


                }
                _attractions = attractionDataList.ToArray();
                _attractionsCity = attractionDataListCity.ToArray();
                _attractionsRegion = attractionDataListRegion.ToArray();

                Console.WriteLine(_attractions);
                Console.WriteLine(_attractionsCity);
                Console.WriteLine(_attractionsRegion);
                Console.WriteLine(_attractions);
            }

        }

    }
}
