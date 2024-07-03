using DistanceReacher.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DistanceReacher.Models.Hotspot
{
    public class HotspotDetails
    {

        public class HotspotsInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public string Type { get; set; }
            public string Image { get; set; }
        }

        public static HotspotsInfo[] _hotspots;
        public static HotspotsInfo[] Hotspots
        {
            get
            {
                if (_hotspots != null)
                    return _hotspots;
                else
                    return new HotspotsInfo[0];
            }
            set
            {
                _hotspots = value;
            }
        }


        public class AttractionInfo
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public string Image { get; set; }
            public string Hotspot { get; set; }
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



        public class HotspotInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
            public string Image { get; set; }
            public string Type { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }

        public static HotspotInfo[] _hotspot;
        public static HotspotInfo[] Hotspot
        {
            get
            {
                if (_hotspot != null)
                    return _hotspot;
                else
                    return new HotspotInfo[0];
            }
            set
            {
                _hotspot = value;
            }
        }


        public class Activity
        {
            public string title { get; set; }
            public string link { get; set; }
            public string img_link { get; set; }
            public string description { get; set; }

        }

        public static Activity[] _activities;
        public static Activity[] Activities
        {
            get
            {
                if (_activities != null)
                    return _activities;
                else
                    return new Activity[0];
            }
            set
            {
                _activities = value;
            }
        }



        public static async Task LoadHotspots()
        {
            string json = await ApiServiceDR.GetJsonFromAPI("hotspots?populate=*");

            var response = JsonConvert.DeserializeObject<ApiHotspotResponse>(json);

            if (response?.Data != null)
            {
                List<HotspotsInfo> hotspotNames = new List<HotspotsInfo>();
                for (int i = 0; i < response.Data.Length; i++)
                {

                    HotspotsInfo hotInfo = new HotspotsInfo
                    {
                        Name = response.Data[i].attributes.name,
                        Description = response.Data[i].attributes.description,
                        Latitude = response.Data[i].attributes.lat,
                        Longitude = response.Data[i].attributes.lng,
                        Type = response.Data[i].attributes.type,
                        Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.image.data.attributes.url,
                    };

                    hotspotNames.Add(hotInfo);
                }
                _hotspots = hotspotNames.ToArray();
            }

        }

        public static async Task LoadActivity(string link)
        {
            string api_link = $"hotspots/?populate[0]=image&populate[1]=attractions.image&filters[name][$eq]={link}&populate[2]=activities";
            string json = await ApiServiceDR.GetJsonFromAPI(api_link);

            var response = JsonConvert.DeserializeObject<ApiHotspotResponse>(json);

            if (response?.Data != null)
            {
                List<Activity> activityNames = new List<Activity>();
                for (int i = 0; i < response.Data.Length; i++)
                {

                    for (int j = 0; j < response.Data[i].attributes.activities.data.Length; j++)
                    {

                        Activity hotInfo = new Activity
                        {
                            title = response.Data[i].attributes.activities.data[j].attributes.title,
                            link = response.Data[i].attributes.activities.data[j].attributes.link,
                            img_link = response.Data[i].attributes.activities.data[j].attributes.img_link,
                            description = response.Data[i].attributes.activities.data[j].attributes.description,
                        };

                        activityNames.Add(hotInfo);
                    }


                }
                _activities = activityNames.ToArray();
            }

        }


        public static async Task LoadHotspotAttactions(string link)
        {

            string api_link = $"hotspots/?populate[0]=image&populate[1]=attractions.image&filters[name][$eq]={link}";

            string json = await ApiServiceDR.GetJsonFromAPI(api_link);

            var response = JsonConvert.DeserializeObject<ApiHotspotResponse>(json);

            if (response?.Data != null)
            {
                HotspotInfo[] hotspotData = new HotspotInfo[response.Data.Length];
                for (int i = 0; i < response.Data.Length; i++)
                {
                    hotspotData[i] = new HotspotInfo
                    {
                        Id = response.Data[i].id,
                        Name = response.Data[i].attributes.name,
                        Description = response.Data[i].attributes.description,
                        Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.image.data.attributes.url,
                        Type = response.Data[i].attributes.type,
                        Latitude = response.Data[i].attributes.lat,
                        Longitude = response.Data[i].attributes.lng,
                    };


                    if (link != null)
                    {
                        List<AttractionInfo> attractionDataList = new List<AttractionInfo>();

                        for (int j = 0; j < response.Data[i].attributes.attractions.data.Length; j++)
                        {

                            AttractionInfo attractionInfo = new AttractionInfo
                            {
                                Index = j,
                                Name = response.Data[i].attributes.attractions.data[j].attributes.name,
                                Description = response.Data[i].attributes.attractions.data[j].attributes.description,
                                Latitude = response.Data[i].attributes.attractions.data[j].attributes.lat,
                                Longitude = response.Data[i].attributes.attractions.data[j].attributes.lng,
                                Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.attractions.data[j].attributes.image.data.attributes.url,
                                Hotspot = response.Data[i].attributes.name,

                            };

                            attractionDataList.Add(attractionInfo);
                        }
                        _attractions = attractionDataList.ToArray();
                    }

                }
                _hotspot = hotspotData;
                Console.WriteLine(_hotspot);
            }

        }

    }

}
