using DistanceReacher.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Models.Country
{
    public class CountryDetails
    {

        public class Country
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public string Image { get; set; }

        }

        public static Country[] _countrys;
        public static Country[] Countrys
        {
            get
            {
                if (_countrys != null)
                    return _countrys;
                else
                    return new Country[0];
            }
            set
            {
                _countrys = value;
            }
        }



        public class HotspotInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public string Image { get; set; }
        }

        public static HotspotInfo[] _hotspots;
        public static HotspotInfo[] Hotspots
        {
            get
            {
                if (_hotspots != null)
                    return _hotspots;
                else
                    return new HotspotInfo[0];
            }
            set
            {
                _hotspots = value;
            }
        }



        public static HotspotInfo[] _citys;
        public static HotspotInfo[] Citys
        {
            get
            {
                if (_citys != null)
                    return _citys;
                else
                    return new HotspotInfo[0];
            }
            set
            {
                _citys = value;
            }
        }

        public static HotspotInfo[] _region;
        public static HotspotInfo[] Regions
        {
            get
            {
                if (_region != null)
                    return _region;
                else
                    return new HotspotInfo[0];
            }
            set
            {
                _region = value;
            }
        }




        public class Info
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public InfoDetails[] Detail { get; set; }
        }

        public static Info[] _infos;
        public static Info[] Infos
        {
            get
            {
                if (_countrys != null)
                    return _infos;
                else
                    return new Info[0];
            }
            set
            {
                _infos = value;
            }
        }



        public class InfoDetails
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Boolean Hotspot { get; set; }
        }

        public static InfoDetails[] _infodetails;
        public static InfoDetails[] Infodetails
        {
            get
            {
                if (_infodetails != null)
                    return _infodetails;
                else
                    return new InfoDetails[0];
            }
            set
            {
                _infodetails = value;
            }
        }






        public static async Task LoadCountryHotspots(string type)
        {
            string api_link = $"countries?populate[hotspots][fields][0]=name&populate[hotspots][fields][1]=description&populate[hotspots][fields][2]=type&populate[image][fields][0]=url&populate[hotspots][filters][type][$eq]={type}";

            if (type == null)
            {
                api_link = "countries/?populate[0]=image.url&populate[1]=hotspots.image";
            }
            string json = await ApiServiceDR.GetJsonFromAPI(api_link);

            var response = JsonConvert.DeserializeObject<ApiCountryInfoResponse>(json);

            if (response?.Data != null)
            {
                Country[] countryData = new Country[response.Data.Length];
                for (int i = 0; i < response.Data.Length; i++)
                {
                    countryData[i] = new Country
                    {
                        Name = response.Data[i].attributes.name,
                        Description = response.Data[i].attributes.description,
                        Latitude = response.Data[i].attributes.lat,
                        Longitude = response.Data[i].attributes.lng,
                        Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.image.data.attributes.url,

                    };


                    List<HotspotInfo> hotspotDataList = new List<HotspotInfo>();
                    List<HotspotInfo> cityDataList = new List<HotspotInfo>();
                    List<HotspotInfo> regionDataList = new List<HotspotInfo>();

                    for (int j = 0; j < response.Data[i].attributes.hotspots.data.Length; j++)
                    {

                        HotspotInfo hotspotInfo = new HotspotInfo
                        {
                            Name = response.Data[i].attributes.hotspots.data[j].attributes.name,
                            Description = response.Data[i].attributes.hotspots.data[j].attributes.description,
                            Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.hotspots.data[j].attributes.image.data.attributes.url,

                        };
                        hotspotDataList.Add(hotspotInfo);
                        if (response.Data[i].attributes.hotspots.data[j].attributes.type == "region")
                        {
                            regionDataList.Add(hotspotInfo);
                        }
                        else
                        {
                            cityDataList.Add(hotspotInfo);
                        }

                    }
                    _hotspots = hotspotDataList.ToArray();
                    _citys = cityDataList.ToArray();
                    _region = regionDataList.ToArray();

                }
                _countrys = countryData;
            }

        }


        public static async Task LoadCountryInfos()
        {
            string api_link = "countryinfos?populate[image][fields][0]=url&populate[info][fields][0]=name&populate[info][fields][1]=description&populate[info][fields][2]=hotspot";

            string json = await ApiServiceDR.GetJsonFromAPI(api_link);

            var response = JsonConvert.DeserializeObject<ApiCountryInfoResponse>(json);

            if (response?.Data != null)
            {
                Info[] infoData = new Info[response.Data.Length];
                for (int i = 0; i < response.Data.Length; i++)
                {
                    List<InfoDetails> infoDataList = new List<InfoDetails>();
                    for (int j = 0; j < response.Data[i].attributes.info.Length; j++)
                    {

                        InfoDetails DataList = new InfoDetails
                        {
                            Name = response.Data[i].attributes.info[j].name,
                            Description = response.Data[i].attributes.info[j].description,
                        };

                        infoDataList.Add(DataList);


                    }

                    infoData[i] = new Info
                    {
                        Name = response.Data[i].attributes.name,
                        Description = response.Data[i].attributes.description,
                        Image = ApiServiceDR.BaseUrl + response.Data[i].attributes.image.data.attributes.url,
                        Detail = infoDataList.ToArray(),
                    };

                }
                _infos = infoData;
        }



    }




    }
}
